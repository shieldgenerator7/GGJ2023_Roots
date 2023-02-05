using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float coyoteTime = 0.1f;
    public float bounceWindow = 0.1f;
    public float fallThroughDuration = 0.1f;
    public List<int> groundLayerIndices;
    public Transform bottom;

    [SerializeField]
    private PlayerState playerState;
    public delegate void OnPlayerStateChanged(PlayerState playerState);
    public event OnPlayerStateChanged onPlayerStateChanged;

    private Rigidbody2D rb2d;
    private Rigidbody2D ridingRB2D;
    private Collider2D standingColl2D;

    private float fallThroughTime = 0;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        if (rb2d.velocity.y <= 0 && playerState.jumping)
        {
            playerState.jumping = false;
            playerState.falling = !playerState.grounded;
            onPlayerStateChanged?.Invoke(playerState);
        }
        if (ridingRB2D)
        {
            playerState.influenceMovement = ridingRB2D.velocity.x;
            onPlayerStateChanged?.Invoke(playerState);
        }
        else
        {
            if (playerState.influenceMovement != 0)
            {
                playerState.influenceMovement = 0;
                onPlayerStateChanged?.Invoke(playerState);
            }
        }
    }

    public void processInputState(InputState inputState)
    {
        //Movement
        playerState.moveDirection = inputState.movementDirection.x;
        playerState.running = inputState.run;
        //Look Direction
        playerState.lookDirection = inputState.lookDirection;
        //Jumping
        if (playerState.jumping != inputState.jump)
        {
            if (!playerState.jumping && inputState.jump)
            {
                if (inputState.movementDirection.y < 0)
                {
                    if (standingColl2D?.GetComponent<PlatformEffector2D>())
                    {
                        if (!playerState.jumpConsumed)
                        {
                            GetComponent<Collider2D>().isTrigger = true;
                            rb2d.velocity = Vector2.down;
                            if (fallThroughTime == 0)
                            {
                                fallThroughTime = Time.time;
                            }
                            playerState.jumpConsumed = true;
                        }
                    }
                    else
                    {
                        GetComponent<Collider2D>().isTrigger = false;
                    }
                }
                else if ((playerState.grounded || Time.time <= playerState.lastGroundTime + coyoteTime)
                    && !playerState.jumpConsumed
                )
                {
                    playerState.jumping = true;
                    playerState.jumpConsumed = true;
                    playerState.falling = false;
                    //playerState.grounded = true;
                    if (Time.time <= playerState.lastAirTime + bounceWindow)
                    {
                        playerState.superJumping = true;
                    }

                }
            }
            else if (playerState.jumping && !inputState.jump)
            {
                playerState.jumping = false;
                playerState.superJumping = false;
                playerState.lastFallVelocity = 0;
                if (!playerState.grounded)
                {
                    playerState.falling = true;
                }
            }
        }
        if (!inputState.jump)
        {
            playerState.jumpConsumed = false;
        }
        if (fallThroughTime > 0)
        {
            if (Time.time >= fallThroughTime + fallThroughDuration)
            {
                standingColl2D = null;
                GetComponent<Collider2D>().isTrigger = false;
                fallThroughTime = 0;
            }
        }
        //Ability
        playerState.ability1 = inputState.ability1;
        playerState.ability2 = inputState.ability2;
        //Delegate
        onPlayerStateChanged?.Invoke(playerState);
    }


    ///TODO: move to some other script, perhaps the environment state updater one
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].point.y <= bottom.position.y)
        {
            Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.KillMe();
                return;
            }
            setGrounded(true);
            //if the player just landed
            if (collision.relativeVelocity.y > 0)
            {
                playerState.lastFallVelocity = collision.relativeVelocity.y;
            }
            if (groundLayerIndices.Contains(collision.collider.gameObject.layer))
            {
                ride(collision.collider.gameObject);
                stand(collision.collider.gameObject);
            }
        }
        else
        {
            Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                transform.position = FindObjectOfType<TreeGameObject>().transform.position;
                return;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].point.y <= bottom.position.y)
        {
            setGrounded(true);
            if (groundLayerIndices.Contains(collision.collider.gameObject.layer))
            {
                ride(collision.collider.gameObject);
                stand(collision.collider.gameObject);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.contacts.Length == 0 || collision.contacts[0].point.y < bottom.position.y)
        {
            setGrounded(false);
            ride(null);
            stand(null);
        }
    }

    private void setGrounded(bool grounded)
    {
        if (grounded)
        {
            //if the player just landed
            if (!playerState.grounded)
            {
                playerState.lastAirTime = Time.time;
            }
            playerState.grounded = true;
            playerState.lastGroundTime = Time.time;
            onPlayerStateChanged?.Invoke(playerState);
        }
        else
        {
            //if the player just took off
            if (playerState.grounded)
            {
                playerState.lastGroundTime = Time.time;
            }
            playerState.grounded = false;
            onPlayerStateChanged?.Invoke(playerState);
        }
    }

    private void ride(GameObject go)
    {
        if (!go)
        {
            ridingRB2D = null;
            return;
        }
        ridingRB2D = go.GetComponent<Rigidbody2D>();
        if (!ridingRB2D)
        {
            ridingRB2D = go.GetComponentInParent<Rigidbody2D>();
        }
        if (!ridingRB2D)
        {
            ridingRB2D = go.GetComponentInChildren<Rigidbody2D>();
        }
    }

    private void stand(GameObject go)
    {
        if (!go)
        {
            standingColl2D = null;
            return;
        }
        standingColl2D = go.GetComponent<Collider2D>();
        if (!standingColl2D)
        {
            standingColl2D = go.GetComponentInParent<Collider2D>();
        }
        if (!standingColl2D)
        {
            standingColl2D = go.GetComponentInChildren<Collider2D>();
        }
    }
}
