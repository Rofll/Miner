using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectModel<TObjectTypeEnum> where TObjectTypeEnum: System.Enum  //IObjectModel<TObjectTypeEnum>
{

    protected TObjectTypeEnum objectType;
    protected int count;


    public TObjectTypeEnum ObjectType { get; }

    public int ObjectCount { get; }

    public abstract void AddObject(int count);
}
