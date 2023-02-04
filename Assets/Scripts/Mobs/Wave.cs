using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/WaveObject", order = 1)]
public class Wave : ScriptableObject
{
    public List<MobGroup> Mobs = new List<MobGroup>();

}

[Serializable]
public class MobGroup
{
    public GameObject Mob;
    public int Count;

}
