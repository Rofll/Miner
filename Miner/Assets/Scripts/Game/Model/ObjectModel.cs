using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectModel<TObjectTypeEnum> where TObjectTypeEnum: System.Enum  //IObjectModel<TObjectTypeEnum>
{

    protected TObjectTypeEnum objectType;
    protected int count;


    public TObjectTypeEnum ObjectType
    {
        get { return objectType; }
    }

    public int ObjectCount
    {
        get { return count; }
    }

    public void AddObject(int count)
    {
        this.count += count;
    }
}
