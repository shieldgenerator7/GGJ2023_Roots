using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public List<PlayerAttributes> attributesList;

    private PlayerAttributes attributes;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void processPlayerState(PlayerState playerState)
    {
        //Transform
        if (playerState.grounded || !attributes)
        {
            attributes = attributesList[playerState.formIndex];
        }
        //Movement
        Vector2 vel = rb2d.velocity;
        vel.x = playerState.moveDirection
            * ((playerState.running) ? attributes.runSpeed : attributes.walkSpeed);
        if (playerState.jumping && playerState.grounded)
        {
            vel.y = attributes.jumpForce;
            if (playerState.superJumping)
            {
                vel.y += Mathf.Abs(playerState.lastFallVelocity);
            }
        }
        else if (!playerState.jumping && !playerState.grounded)
        {
            if (vel.y > 0)
            {
                vel.y = 0;
            }
        }
        vel += playerState.influenceDirection;
        rb2d.velocity = vel;
    }
}
