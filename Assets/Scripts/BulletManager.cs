using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class BulletManager : MonoBehaviour
{
    private Rigidbody bulletForce;
    private float bulletSpeed;
    private void Start()
    {
        bulletForce = GetComponent<Rigidbody>();
        bulletSpeed = 5f;
        BulletMotion();
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the bullet when collide with obstacle
        Destroy(gameObject, 0.1f);
    }
    private void BulletMotion()
    {
        // Apply force from local spawnpoint transform
        bulletForce.AddRelativeForce(Vector2.up * bulletSpeed, ForceMode.Impulse);
    }
}
