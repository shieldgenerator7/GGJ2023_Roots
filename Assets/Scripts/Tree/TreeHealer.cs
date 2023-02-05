using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealer : MonoBehaviour
{
    public float healDelay = 1;
    public int healAmount = 1;

    private float lastHealTime = 0;

    private TreeGameObject tree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tree)
        {
            if (Time.time >= lastHealTime + healDelay)
            {
                lastHealTime = Time.time;
                tree.treeHealth.Health += healAmount;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkHeal(collision.gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        checkHeal(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        checkHeal(collision.gameObject, false);
    }


    void checkHeal(GameObject go, bool heal =true)
    {
        TreeGameObject tree = go.GetComponent<TreeGameObject>();
        if (tree)
        {
            this.tree = tree;
            if (!heal)
            {
                this.tree = null;
            }
        }
    }
}
