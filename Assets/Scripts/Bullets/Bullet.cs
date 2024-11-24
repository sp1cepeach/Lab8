using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    new Rigidbody2D rigidbody;
    Action Despawn;

    public void Initialize()
    {
        gameObject.SetActive(false);
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnSpawn(Transform transform, Action Despawn)
    {
        gameObject.SetActive(true);
        this.transform.SetPositionAndRotation(transform.position, transform.rotation);
        rigidbody.AddRelativeForce(Vector2.up * speed, ForceMode2D.Impulse);
        this.Despawn = Despawn;
    }

    public void OnDespawn()
    {
        gameObject.SetActive(false);
        rigidbody.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Alien") || collider.CompareTag("BorderTop"))
        {
            Despawn();
        }
    }
}
