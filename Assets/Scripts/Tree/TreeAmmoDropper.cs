using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAmmoDropper : MonoBehaviour
{
    public float dropDelay = 1;
    public int dropAmount = 1;
    public Vector2 dropoffset = Vector2.down;

    public GameObject ammoPrefab;

    private float lastDropTime = 0;

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
            if (Time.time >= lastDropTime + dropDelay)
            {
                lastDropTime = Time.time;
                for (int i = 0; i < dropAmount; i++)
                {
                    drop();
                }
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

    void drop()
    {
        GameObject ammo = Instantiate(ammoPrefab);
        Transform leaf = tree.getRandomLeaf();
        if (leaf)
        {
            ammo.transform.position = (Vector2)leaf.position + dropoffset;
        }
    }
}
