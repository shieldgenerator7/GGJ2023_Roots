using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafEffects : MonoBehaviour
{
    public GameObject effect;
    public void TriggerEffect()
    {
        if(effect != null)
        {
            var leaf = Instantiate(effect, transform.parent);
            leaf.transform.position = transform.position;
        }
    }


}
