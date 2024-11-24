using System;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public Action<Alien> onAlienSpawn;
    [SerializeField] Alien alienPrefab;
    float delay = 2;

    void Start()
    {
        Invoke("SpawnAlien", 1);
    }

    void SpawnAlien()
    {
        AlienBuilder alienBuilder = null;
        Func<Alien> instantiateAlien = () =>
            Instantiate(alienPrefab, transform.position, transform.rotation);

        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                alienBuilder = new GreenAlienBuilder(instantiateAlien);
                break;
            case 1:
                alienBuilder = new YellowAlienBuilder(instantiateAlien);
                break;
            case 2:
                alienBuilder = new PinkAlienBuilder(instantiateAlien);
                break;
        }

        alienBuilder.BuildSprite();
        alienBuilder.BuildSpeed();
        alienBuilder.BuildScore();
        alienBuilder.BuildDamage();

        onAlienSpawn?.Invoke(alienBuilder.alien);

        Invoke("SpawnAlien", delay);
        delay = 1 + (0.9f * (delay - 1));
    }
}
