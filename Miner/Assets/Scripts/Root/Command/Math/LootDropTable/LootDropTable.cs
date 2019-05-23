using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Random = UnityEngine.Random;

public class LootDropTable <TObjectModel, TObjectTypeEnum> where TObjectModel: ObjectModel<TObjectTypeEnum>  where TObjectTypeEnum: System.Enum 
{
    float totalWeight = 0;
    float nullebleWeight = 0;

    List<TObjectModel> objectsModel = new List<TObjectModel>();

    private TObjectTypeEnum objectTypeEnumNull;

    Dictionary<TObjectTypeEnum, double> chances = new Dictionary<TObjectTypeEnum, double>();
    Dictionary<TObjectTypeEnum, double> weights = new Dictionary<TObjectTypeEnum, double>();

    Dictionary<TObjectTypeEnum, MathMinMaxDoubleModel> chancesRange = new Dictionary<TObjectTypeEnum, MathMinMaxDoubleModel>();

    public List<TObjectModel> GetLoot(List<BucketObjectModel<TObjectTypeEnum>> lootObjects, uint minDrop, uint maxDrop, bool isWithoutReplacement = true)
    {

        if (minDrop > maxDrop)
        {
            UnityEngine.Debug.LogError(String.Format("minDrop > maxDrop: {0} > {1}", minDrop, maxDrop));
            return null;
        }

        try
        {
            objectTypeEnumNull = (TObjectTypeEnum) System.Enum.Parse(typeof(TObjectTypeEnum), "Null");
        }

        catch
        {
            UnityEngine.Debug.LogError("objectTypeEnumNull == NULL");
            UnityEngine.Debug.LogError("Please add Null field to " + typeof(TObjectTypeEnum).ToString());
            return null;
        }

        for (int i = 0; i < maxDrop; i++)
        {
            InitWeight(lootObjects);

            if (i == minDrop)
            {
                totalWeight += nullebleWeight;
                weights.Add(objectTypeEnumNull, nullebleWeight);
            }

            else if (i > minDrop)
            {
                totalWeight += nullebleWeight;
                weights[objectTypeEnumNull] = nullebleWeight;
            }

            CalculateChance();
            ChangesRange();

            float random = Random.Range(0f, 100f);

            GetResource(random, lootObjects, isWithoutReplacement);
        }
        return objectsModel;
    }

    private void InitWeight(List<BucketObjectModel<TObjectTypeEnum>> lootObjects)
    {
        totalWeight = 0;
        nullebleWeight = 0;

        foreach (BucketObjectModel<TObjectTypeEnum> lootObject in lootObjects)
        {
            if (!lootObject.Item.Equals(objectTypeEnumNull))
            {
                totalWeight += lootObject.Weight * lootObject.Count;

                if (!weights.ContainsKey(lootObject.Item))
                {
                    weights.Add(lootObject.Item, lootObject.Weight * lootObject.Count);
                }

                else
                {
                    weights[lootObject.Item] = lootObject.Weight * lootObject.Count;
                }
            }

            else
            {
                nullebleWeight = lootObject.Weight * lootObject.Count;
            }
        }
    }

    private void CalculateChance()
    {
        foreach (TObjectTypeEnum objectType in weights.Keys)
        {
            double chance = weights[objectType] / totalWeight * 100;

            if (!chances.ContainsKey(objectType))
            {
                chances.Add(objectType, chance);
            }

            else
            {
                chances[objectType] = chance;
            }
        }
    }

    private void ChangesRange()
    {
        bool isFirstPass = true;
        double previousValue = 0;

        foreach (var chance in chances.OrderBy(key => key.Value))
        {

            MathMinMaxDoubleModel minMaxDoubleModel;

            if (isFirstPass)
            {
                minMaxDoubleModel = new MathMinMaxDoubleModel(0, chance.Value);
                previousValue = chance.Value;

                isFirstPass = false;
            }
            else
            {
                minMaxDoubleModel = new MathMinMaxDoubleModel(previousValue, chance.Value + previousValue);
                previousValue = chance.Value + previousValue;
            }

            if (!chances.ContainsKey(chance.Key))
            {
                chancesRange.Add(chance.Key, minMaxDoubleModel);
            }

            else
            {
                chancesRange[chance.Key] = minMaxDoubleModel;
            }
        }
    }

    private void GetResource(float random , List<BucketObjectModel<TObjectTypeEnum>> lootObjects, bool isWithoutReplacement)
    {
        foreach (var chanceRange in chancesRange)
        {
            if (random > chanceRange.Value.Min && random < chanceRange.Value.Max)
            {
                if (!chanceRange.Key.Equals(objectTypeEnumNull))
                {
                    bool isResourceModelContain = false;

                    foreach (ObjectModel<TObjectTypeEnum> objectModel in objectsModel)
                    {
                        if (objectModel.ObjectType.Equals(chanceRange.Key))
                        {
                            objectModel.AddObject(1);
                            isResourceModelContain = true;
                            break;
                        }
                    }

                    if (!isResourceModelContain)
                    {
                        objectsModel.Add((TObjectModel)Activator.CreateInstance(typeof(TObjectModel), new object[]{ chanceRange.Key,  1}));
                    }
                }

                if (isWithoutReplacement)
                {
                    DeleteItemFromBucket(lootObjects, chanceRange);
                }

                break;
            }
        }
    }

    private void DeleteItemFromBucket(List<BucketObjectModel<TObjectTypeEnum>> lootObjects, KeyValuePair<TObjectTypeEnum, MathMinMaxDoubleModel> chanceRange)
    {
        foreach (BucketObjectModel<TObjectTypeEnum> lootObject in lootObjects)
        {
            if (lootObject.Item.Equals(chanceRange.Key))
            {
                lootObject.DecreaseCount(1);

                if (lootObject.Count <= 0)
                {
                    ClearLists(lootObjects, lootObject);
                }

                break;
            }
        }
    }

    private void ClearLists(List<BucketObjectModel<TObjectTypeEnum>> lootObjects, BucketObjectModel<TObjectTypeEnum> lootObject)
    {
        lootObjects.Remove(lootObject);
        chancesRange.Remove(lootObject.Item);
        weights.Remove(lootObject.Item);
        chances.Remove(lootObject.Item);
    }
}
