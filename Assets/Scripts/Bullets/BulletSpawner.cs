using System;
using UnityEngine;

public class BulletSpawner
{
    Bullet[] pool;
    int size;

    public BulletSpawner(int capacity, Func<Bullet> instantiateBullet) {
        pool = new Bullet[capacity];
        size = 0;

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = instantiateBullet();
            pool[i].Initialize();
        }
    }

    public void SpawnBullet(Transform transform)
    {
        if (size < pool.Length)
        {
            Bullet bullet = pool[size];
            bullet.OnSpawn(transform, () => DespawnBullet(bullet));
            size++;
        }
    }

    void DespawnBullet(Bullet bullet)
    {
        if (size > 0)
        {
            int i = Array.IndexOf(pool, bullet);
            pool[i] = pool[size - 1];
            pool[size - 1] = bullet;
            size--;
            bullet.OnDespawn();
        }
    }
}
