using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class TreeGameObject : MonoBehaviour
{
    [Header("Settings")]
    public int maxHealth = 100;

    [Header("Components")]
    public List<SpriteRenderer> leaves;

    public TreeHealth treeHealth { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        treeHealth = new TreeHealth(maxHealth);
        treeHealth.onHealthChanged += updateLeaves;
    }

    public void Damage(int damage)
    {
        treeHealth.Health -= damage;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void updateLeaves(int health)
    {
        //Show / hide leaves based on the percentage of health the tree has
        float percent = ((float)health) / ((float)treeHealth.MaxHealth);
        bool alive = health > 0;
        for (int i = 0; i < leaves.Count; i++)
        {
            if(alive && (float)i / (float)leaves.Count <= percent)
            {
                leaves[i].gameObject.SetActive(true);
            }
            else
            {
                leaves[i].GetComponent<LeafEffects>().TriggerEffect();
                leaves[i].gameObject.SetActive(false);
            }
   
        }
    }
}
