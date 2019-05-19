﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LootDropTable
{
    double totalWeight = 0;
    double nullebleWeight = 0;

    List<ResourceModel> resourcesModel = new List<ResourceModel>();

    Dictionary<ResourceTypesEnum, double> chances = new Dictionary<ResourceTypesEnum, double>();
    Dictionary<ResourceTypesEnum, double> weights = new Dictionary<ResourceTypesEnum, double>();

    Dictionary<ResourceTypesEnum, MathMinMaxDoubleModel> chancesRange = new Dictionary<ResourceTypesEnum, MathMinMaxDoubleModel>();

    public List<ResourceModel> GetLoot(List<LootObjectModel> lootObjects, uint minDrop, uint maxDrop)
    {
        for (int i = 0; i < maxDrop; i++)
        {
            InitWeight(lootObjects);

            if (i == minDrop - 1)
            {
                totalWeight += nullebleWeight;
                weights.Add(ResourceTypesEnum.Null, nullebleWeight);
            }

            CalculateChance();
            ChangesRange();

            float random = Random.Range(0f, 100f);

            GetResource(random, lootObjects);
        }

        return resourcesModel;
    }

    private void InitWeight(List<LootObjectModel> lootObjects)
    {
        totalWeight = 0;
        nullebleWeight = 0;

        foreach (LootObjectModel lootObject in lootObjects)
        {
            if (lootObject.Item != ResourceTypesEnum.Null)
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
        foreach (ResourceTypesEnum resourceType in weights.Keys)
        {
            double chance = weights[resourceType] / totalWeight * 100;

            if (!chances.ContainsKey(resourceType))
            {
                chances.Add(resourceType, chance);
            }

            else
            {
                chances[resourceType] = chance;
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
                minMaxDoubleModel = new MathMinMaxDoubleModel(previousValue, chance.Value);
                previousValue = chance.Value;
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

    private void GetResource(float random , List<LootObjectModel> lootObjects)
    {
        foreach (var chanceRange in chancesRange)
        {
            if (random > chanceRange.Value.Min && random < chanceRange.Value.Max)
            {
                if (chanceRange.Key != ResourceTypesEnum.Null)
                {
                    bool isResourceModelContain = false;

                    foreach (ResourceModel resourceModel in resourcesModel)
                    {
                        if (resourceModel.ResourceType == chanceRange.Key)
                        {
                            resourceModel.AddResource(1);
                            isResourceModelContain = true;
                            break;
                        }
                    }

                    if (!isResourceModelContain)
                    {
                        resourcesModel.Add(new ResourceModel(chanceRange.Key, 1));
                    }
                }

                foreach (LootObjectModel lootObject in lootObjects)
                {
                    if (lootObject.Item == chanceRange.Key)
                    {
                        lootObject.DecreaseCount(1);

                        if (lootObject.Count <= 0)
                            lootObjects.Remove(lootObject);

                        break;
                    }
                }

                break;
            }
        }
    }
}

public class MathMinMaxDoubleModel
{
    public MathMinMaxDoubleModel(double min, double max)
    {
        this.min = min;
        this.max = max;
    }

    private readonly double min;
    private readonly double max;

    public double Min
    {
        get { return min; }
    }

    public double Max
    {
        get { return max; }
    }

}