using UnityEngine;

public class Score : MonoBehaviour
{
    public int score { get { return _score; } }
    private int _score;

    void Start()
    {
        _score = 0;
        AlienSpawner alienSpawner = FindAnyObjectByType<AlienSpawner>();
        alienSpawner.onAlienSpawn += (alien) =>
        {
            alien.OnAlienHit += () => IncreaseScore(alien.score);
        };
    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + score);
    }
}
