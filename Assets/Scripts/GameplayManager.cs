using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager gameplay;
    public Transform[] SpawnPoints;
    public GameObject asteroidSpawner;
    public static Camera screenCamera;
    public int asteroidCount, maxCount;
    private float size;
    private int spawnRandom;
    private void Start()
    {
        screenCamera = Camera.main;
        asteroidCount = 3;
        maxCount = 4;
        gameplay = this;
        spawnRandom = Random.Range(0, 3);
        AsteroidCreater(2, asteroidCount);
    }

    public void AsteroidCreater(int type, int asteroidCount)
    {
        if(maxCount <= 0)
        {
            maxCount = 3;
            return;
        }
        maxCount--;
        switch(type)
        {
            case 1:
                size = 0.5f;
                break;
            case 2:
                size = 1f;
                break;
        }
        for (int i = 0; i < asteroidCount; ++i)
        {
            GameObject Asteroid = Instantiate(asteroidSpawner, SpawnPoints[i].position, SpawnPoints[i].rotation);
            Asteroid.transform.localScale = new Vector3(Asteroid.transform.localScale.x * size, Asteroid.transform.localScale.y * size, Asteroid.transform.localScale.z * size);
            Asteroid.GetComponent<AsteroidManager>().asteroidType = type;
        }
    }
}
