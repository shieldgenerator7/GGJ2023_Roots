using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerState
{
    /// <summary>
    /// Horizontal direction the player intends on moving
    /// </summary>
    public float moveDirection;
    /// <summary>
    /// The vector the bow and arrow is pointing
    /// </summary>
    public Vector2 lookDirection;
    /// <summary>
    /// True: the player intends to go fast
    /// </summary>
    public bool running;
    /// <summary>
    /// True: in air and intends to be going up
    /// </summary>
    public bool jumping;
    public bool jumpConsumed;
    public bool superJumping;
    /// <summary>
    /// True: in air and intends to be going down
    /// </summary>
    public bool falling;
    /// <summary>
    /// True: on the ground
    /// </summary>
    public bool grounded;
    public float lastGroundTime;
    public float lastAirTime;
    public float lastFallVelocity;
    /// <summary>
    /// True: up against a wall
    /// </summary>
    public bool walled;
    /// <summary>
    /// True: a ceiling is in range of the player's feet
    /// </summary>
    public bool cellinged;
    /// <summary>
    /// True: intends on using ability 1
    /// </summary>
    public bool ability1;
    /// <summary>
    /// True: intends on using ability 2
    /// </summary>
    public bool ability2;
    /// <summary>
    /// The form index
    /// </summary>
    public int formIndex;

    public override string ToString()
    {
        return $"move: {moveDirection}, running: {running}, jumping: {jumping}, grounded: {grounded}, form: {formIndex}";
    }
}
