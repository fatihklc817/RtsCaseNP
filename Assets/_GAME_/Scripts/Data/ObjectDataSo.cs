using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "ScriptableObjects/ObjectData", order = 1)]
public class ObjectDataSo : ScriptableObject
{
    public float Speed;
    public float FireRate;
    public float Range;
}
