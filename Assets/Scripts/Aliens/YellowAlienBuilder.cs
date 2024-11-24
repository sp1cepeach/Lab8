using System;
using UnityEngine;

public class YellowAlienBuilder : AlienBuilder
{
    public YellowAlienBuilder(Func<Alien> instantiateAlien)
    {
        _alien = instantiateAlien();
        alien.Initialize();
    }

    public override void BuildSprite()
    {
        alien.spriteRenderer.sprite = Resources.Load<Sprite>("alienYellow");
    }

    public override void BuildSpeed()
    {
        alien.speed = 2;
    }

    public override void BuildScore()
    {
        alien.score = 2;
    }

    public override void BuildDamage()
    {
        alien.damage = 2;
    }
}
