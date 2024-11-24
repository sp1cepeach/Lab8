using System;
using UnityEngine;

public class PinkAlienBuilder : AlienBuilder
{
    public PinkAlienBuilder(Func<Alien> instantiateAlien)
    {
        _alien = instantiateAlien();
        alien.Initialize();
    }

    public override void BuildSprite()
    {
        alien.spriteRenderer.sprite = Resources.Load<Sprite>("alienPink");
    }

    public override void BuildSpeed()
    {
        alien.speed = 1;
    }

    public override void BuildScore()
    {
        alien.score = 1;
    }

    public override void BuildDamage()
    {
        alien.damage = 3;
    }
}
