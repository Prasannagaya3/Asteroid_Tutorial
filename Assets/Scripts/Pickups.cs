using UnityEngine;

public class Pickups : MonoBehaviour
{
    public GameObject rocketParent;

    private void Start()
    {
        rocketParent = GameObject.Find("Rocket");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Rocket"))
        {
            GameplayManager.gameplay.EnableShield();
        }
    }
}