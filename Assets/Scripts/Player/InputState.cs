using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InputState
{
    public Vector2 movementDirection;
    public Vector2 lookPosition;
    public Vector2 lookDirection;
    public bool jump;
    public bool run;
    public bool interact;
    public bool ability1;
    public bool ability2;

    public override string ToString()
    {
        return $"move: {movementDirection}, jump: {jump}, run: {run},";
    }

    public static bool operator ==(InputState is1, InputState is2)
    {
        return is1.movementDirection == is2.movementDirection
            && is1.lookPosition == is2.lookPosition
            && is1.lookDirection == is2.lookDirection
            && is1.jump == is2.jump
            && is1.run == is2.run
            && is1.interact == is2.interact
            && is1.ability1 == is2.ability1
            && is1.ability2 == is2.ability2
            ;
    }
    public static bool operator !=(InputState is1, InputState is2)
    {
        return !(is1 == is2);
    }
    public override bool Equals(object obj)
    {
        return obj is InputState && this == (InputState)obj;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
