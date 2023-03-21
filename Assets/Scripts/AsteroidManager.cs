using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(MeshCollider))]
public class AsteroidManager : MonoBehaviour
{
    private Rigidbody asteroidForce;
    public int asteroidType;
    private float asteroidRotateSpeed, asteroidVelocitySpeed;
    private float asteroidXValue, asteroidYValue, asteroidZValue;
    private float asteroidXMotion, asteroidYMotion;

    private void Start()
    {
        asteroidForce = GetComponent<Rigidbody>();
        asteroidRotateSpeed = 0.1f;
        asteroidVelocitySpeed = 1f;
        ResetAsteroid();
    }
    private void FixedUpdate()
    {
        AsteroidMotion();
        ScreenSize();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Rocket"))
        {
            GameUI.UIInstance.RocketHealthUpdate();
        }
        if (collision.transform.CompareTag("Bullet"))
        {
            if(asteroidType == 2)
            {
                GameplayManager.gameplay.AsteroidCreater(1, 3);
            }
            else if(asteroidType == 1)
            {
                GameplayManager.gameplay.AsteroidCreater(2, 1);
                GameUI.UIInstance.ScoreUpdate();
            }
            Destroy(gameObject);
        }
    }
    public void ScreenSize()
    {
        float sceneWidth = GameplayManager.screenCamera.orthographicSize * 2 * GameplayManager.screenCamera.aspect;
        float sceneHeight = GameplayManager.screenCamera.orthographicSize * 2;

        float sceneRightEdge = sceneWidth / 2;
        float sceneLeftEdge = sceneRightEdge * -1;
        float sceneTopEdge = sceneHeight / 2;
        float sceneBottomEdge = sceneTopEdge * -1;

        if (asteroidForce.transform.position.x > sceneRightEdge)
        {
            asteroidForce.transform.position = new Vector2(sceneLeftEdge, asteroidForce.transform.position.y);
        }
        if (asteroidForce.transform.position.x < sceneLeftEdge)
        {
            asteroidForce.transform.position = new Vector2(sceneRightEdge, asteroidForce.transform.position.y);
        }
        if (asteroidForce.transform.position.y > sceneTopEdge)
        {
            asteroidForce.transform.position = new Vector2(asteroidForce.transform.position.x, sceneBottomEdge);
        }
        if (asteroidForce.transform.position.y < sceneBottomEdge)
        {
            asteroidForce.transform.position = new Vector2(asteroidForce.transform.position.x, sceneTopEdge);
        }
    }
    public void ResetAsteroid()
    {
        asteroidXValue = Random.Range(-150, 150);
        asteroidYValue = Random.Range(-150, 150);
        asteroidXValue = Random.Range(-150, 150);
        asteroidXMotion = Random.Range(-7, 7);
        asteroidYMotion = Random.Range(-4, 4);
    }
    public void AsteroidMotion()
    {
        asteroidForce.transform.Rotate(new Vector3(asteroidXValue, asteroidYValue, asteroidZValue) * asteroidRotateSpeed * Time.deltaTime);
        asteroidForce.AddForce(new Vector2(asteroidXMotion, asteroidYMotion) * Time.deltaTime);
        asteroidForce.velocity = new Vector2(Mathf.Clamp(asteroidForce.velocity.x, -asteroidVelocitySpeed, asteroidVelocitySpeed), Mathf.Clamp(asteroidForce.velocity.y, -asteroidVelocitySpeed, asteroidVelocitySpeed));
    }
}