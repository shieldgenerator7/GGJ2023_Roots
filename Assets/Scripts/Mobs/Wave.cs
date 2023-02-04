using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/WaveObject", order = 1)]
public class Wave : ScriptableObject
{
    public List<MobGroup> Mobs = new List<MobGroup>();
    public string WaveAnnouncement = "WAVE";

}

[Serializable]
public class MobGroup
{
    public GameObject Mob;
    public int Count;

}
