using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectModel<TObjectTypeEnum> where TObjectTypeEnum: System.Enum
{
    TObjectTypeEnum ObjectType { get; }

    int ObjectCount { get; }

    void AddObject(int cout);
}
