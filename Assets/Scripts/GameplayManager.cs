using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager gameplay;
    public RocketManager Rocket;
    public Transform[] SpawnPoints;
    public GameObject asteroidSpawner, rocketShield, currentShield;
    public static Camera screenCamera;
    public int asteroidCount, maxCount;
    private float size, xValue, yValue;
    private void Start()
    {
        screenCamera = Camera.main;
        asteroidCount = 3;
        maxCount = 4;
        gameplay = this;
        AsteroidCreater(2, asteroidCount);
        InvokeRepeating("ShieldCreation", 0, 10f);
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
    public void ShieldCreation()
    {
        xValue = Random.Range(-7, 7);
        yValue = Random.Range(-4, 4);
        if (!GameObject.Find("Shield(Clone)"))
        {
            currentShield = Instantiate(rocketShield, new Vector2(xValue, yValue), Quaternion.identity);
            currentShield.SetActive(true);
        }
    }
    public void EnableShield()
    {
        currentShield.transform.SetParent(Rocket.transform);
        currentShield.transform.localPosition = new Vector3(0, 0, 0);
        GameUI.UIInstance.IsShieldPicked = true;
    }
    public void DisableShield()
    {
        GameUI.UIInstance.IsShieldPicked = false;
        currentShield.SetActive(false);
        currentShield.transform.SetParent(null);
        Destroy(currentShield);
    }
}