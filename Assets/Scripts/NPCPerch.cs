using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPerch : MonoBehaviour
{
    private NPC npc;

    public bool HasNPC => npc;

    public void perchNPC(NPC npc)
    {
        this.npc = npc;
        npc.transform.parent = transform;
        npc.transform.localPosition = Vector3.zero;
        npc.Collected = true;

    }

    private void OnDisable()
    {
        if (npc)
        {
            npc.transform.parent = null;
            this.npc = null;
            npc.Collected = false;
        }
    }
}
