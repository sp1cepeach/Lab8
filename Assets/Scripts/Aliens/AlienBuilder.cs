public abstract class AlienBuilder
{
    public Alien alien { get { return _alien; } }
    protected Alien _alien;

    public abstract void BuildSprite();
    public abstract void BuildSpeed();
    public abstract void BuildScore();
    public abstract void BuildDamage();
}
