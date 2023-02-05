
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 5f;
    public GameObject deathEffect;
    public int strength;
    public float jumpRange = 2;
    public float jumpPower = 5;
    public float jumpHeightOffset = 4;

    [Range(0f, 100f)]
    public float DropChance = 25f;
    public GameObject ItemDrop;

    private bool jumped = false;

    private void Awake()
    {
        TreeTracker.Instance?.RegisterMob(gameObject);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (TreeTracker.Instance != null)
        {
            Vector2 treeLocation = TreeTracker.Instance.TreeLocation.position;
            Vector2 treeDir = treeLocation - (Vector2)transform.position;
            if (treeDir.magnitude <= jumpRange)
            {
                if (!jumped)
                {
                    rb.velocity = (treeDir + (Vector2.up * jumpHeightOffset)).normalized * jumpPower;
                    jumped = true;
                }
            }
            else
            {
                if (transform.position.x < treeLocation.x)
                {
                    rb.velocity = new Vector3(speed, 0f, 0f);
                }
                else
                {
                    rb.velocity = new Vector3(speed * -1, 0f, 0f);
                }
            }
        }
        else
        {
            rb.velocity = new Vector3(speed * -1, 0f, 0f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tree")
        {
            collision.gameObject.GetComponent<TreeGameObject>().Damage(strength);
            KillMe();

        }
        jumped = false;
    }

    private void OnDestroy()
    {
        TreeTracker.Instance?.DeregisterMob(gameObject);
    }

    public void KillMe()
    {
        //spawn effect
        if (deathEffect != null)
        {
            var splat = Instantiate(deathEffect, gameObject.transform.parent);
            splat.transform.position = transform.position;

            var spin = Random.Range(0, 100);
            if (spin < DropChance)
            {
                var item = Instantiate(ItemDrop, gameObject.transform.parent);
                item.transform.position = gameObject.transform.position;
            }
        }
        Destroy(gameObject);

    }
}
