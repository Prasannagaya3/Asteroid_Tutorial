using System;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class RocketManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    private Camera screenCamera;
    private GameObject cloneBullet;
    private Rigidbody2D rocketForce;
    private float rocketMovementSpeed, rocketRotationSpeed, rocketVelocitySpeed;

    private void Start()
    {
        if (bulletPrefab != null)
        {
            bulletPrefab.SetActive(false);
        }
        rocketForce = GetComponent<Rigidbody2D>();
        screenCamera = Camera.main;
        rocketMovementSpeed = 5f;
        rocketRotationSpeed = 180f;
        rocketVelocitySpeed = 3f;
    }
    private void FixedUpdate()
    {
        RocketMotion();
        ScreenSize();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            BullerTriggered();
            //ResetRocket();
        }
    }
    public void RocketMotion()
    {
        rocketForce.AddRelativeForce(Vector2.up * rocketMovementSpeed * Input.GetAxis("Vertical"));
        rocketForce.transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rocketRotationSpeed * Time.deltaTime);
        rocketForce.velocity = new Vector2(Mathf.Clamp(rocketForce.velocity.x, -rocketVelocitySpeed, rocketVelocitySpeed), Mathf.Clamp(rocketForce.velocity.y, -rocketVelocitySpeed, rocketVelocitySpeed));
    }
    public void ScreenSize()
    {
        float sceneWidth = screenCamera.orthographicSize * 2 * screenCamera.aspect;
        float sceneHeight = screenCamera.orthographicSize * 2;

        float sceneRightEdge = sceneWidth / 2;
        float sceneLeftEdge = sceneRightEdge * -1;
        float sceneTopEdge = sceneHeight / 2;
        float sceneBottomEdge = sceneTopEdge * -1;

        if (rocketForce.transform.position.x > sceneRightEdge)
        {
            rocketForce.transform.position = new Vector2(sceneLeftEdge, rocketForce.transform.position.y);
        }
        if (rocketForce.transform.position.x < sceneLeftEdge)
        {
            rocketForce.transform.position = new Vector2(sceneRightEdge, rocketForce.transform.position.y);
        }
        if (rocketForce.transform.position.y > sceneTopEdge)
        {
            rocketForce.transform.position = new Vector2(rocketForce.transform.position.x, sceneBottomEdge);
        }
        if (rocketForce.transform.position.y < sceneBottomEdge)
        {
            rocketForce.transform.position = new Vector2(rocketForce.transform.position.x, sceneTopEdge);
        }
    }
    public void ResetRocket()
    {
        rocketForce.transform.position = new Vector2(0, 0);
        rocketForce.transform.rotation = Quaternion.identity;
        rocketForce.velocity = new Vector2(0, 0);
    }
    private void BullerTriggered()
    {
        // Create a bullet profab and apply to the temp gameobject
        cloneBullet = Instantiate(bulletPrefab, new Vector2(bulletSpawnPoint.position.x, bulletSpawnPoint.position.y), transform.rotation);
        // Enable the temp gameobject
        cloneBullet.SetActive(true);
    }
}
