using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "bulletData", menuName = "ScriptableObjects/bulletDataSo", order = 1)]
public class BulletDataSO : ScriptableObject
{
    public GameObject BulletPrefab;
    public float Damage;
    public float BulletSpeed;
}
