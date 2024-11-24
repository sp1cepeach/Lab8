using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Alien : MonoBehaviour
{
    public Action OnAlienHit;
    public Action OnAlienReachPlayer;
    public float speed { get; set; }
    public int score { get; set; }
    public int damage { get; set; }
    public SpriteRenderer spriteRenderer { get { return _spriteRenderer; } }
    private SpriteRenderer _spriteRenderer;
    new Rigidbody2D rigidbody;

    public void Initialize()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.right * (2 + (2 * speed));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag)
        {
            case "Bullet":
                OnAlienHit?.Invoke();
                Destroy(gameObject);
                break;

            case "BorderSides":
                rigidbody.velocity *= -1;
                rigidbody.position += Vector2.down * 3;
                break;

            case "BorderBottom":
                OnAlienReachPlayer?.Invoke();
                Destroy(gameObject);
                break;
        }
    }
}
