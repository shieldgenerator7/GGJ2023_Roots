using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeTracker : MonoBehaviour
{

    public Transform TreeLocation;
    public static TreeTracker Instance;
    public List<GameObject> Mobs;

    public bool isWaveActive
    {
        get
        {
            return Mobs.Count > 0;
        }
    }



    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        if (TreeLocation == null)
        {
            TreeLocation = GameObject.FindGameObjectsWithTag("tree").FirstOrDefault().transform;
        }

    }

    public void RegisterMob(GameObject mob)
    {
        Mobs.Add(mob);
    }

    public void DeregisterMob(GameObject mob)
    {
        Mobs.Remove(mob);
    }
}
