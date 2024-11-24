using System;
using UnityEngine;

public class GreenAlienBuilder : AlienBuilder
{
    public GreenAlienBuilder(Func<Alien> instantiateAlien)
    {
        _alien = instantiateAlien();
        alien.Initialize();
    }

    public override void BuildSprite()
    {
        alien.spriteRenderer.sprite = Resources.Load<Sprite>("alienGreen");
    }

    public override void BuildSpeed()
    {
        alien.speed = 3;
    }

    public override void BuildScore()
    {
        alien.score = 3;
    }

    public override void BuildDamage()
    {
        alien.damage = 1;
    }
}
