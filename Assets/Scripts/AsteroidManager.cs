using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(MeshCollider))]
public class AsteroidManager : MonoBehaviour
{
    [SerializeField] private GameUI rocketHealth;
    private Rigidbody asteroidForce;
    private float asteroidRotateSpeed;
    private float asteroidXValue, asteroidYValue, asteroidZValue;
    private float asteroidXMotion, asteroidYMotion;

    private void Start()
    {
        asteroidForce = GetComponent<Rigidbody>();
        asteroidRotateSpeed = 0.1f;
        ResetAsteroid();
    }
    private void FixedUpdate()
    {
        AsteroidMotion();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Rocket"))
        {
            Debug.Log("PlayerHealthReduce");
            rocketHealth.rocketHealthCount--;
            if(rocketHealth.rocketHealthCount == 0)
            {
                Time.timeScale = 1;
            }
            rocketHealth.RocketHealthUpdate();
        }
        if (collision.transform.CompareTag("Bullet"))
        {
            Debug.Log("Hit");
            //Destroy(gameObject);
        }
        if(collision.transform.CompareTag("OuterSpace"))
        {
            ResetAsteroid();
        }
    }
    public void ResetAsteroid()
    {
        asteroidXValue = Random.Range(-360, 360);
        asteroidYValue = Random.Range(-360, 360);
        asteroidXValue = Random.Range(-360, 360);
        asteroidXMotion = Random.Range(-7, 7);
        asteroidYMotion = Random.Range(-4, 4);
    }

    public void AsteroidMotion()
    {
        asteroidForce.transform.Rotate(new Vector3(asteroidXValue, asteroidYValue, asteroidZValue) * asteroidRotateSpeed * Time.deltaTime);
        asteroidForce.AddForce(new Vector2(asteroidXMotion, asteroidYMotion) * Time.deltaTime);
    }
}