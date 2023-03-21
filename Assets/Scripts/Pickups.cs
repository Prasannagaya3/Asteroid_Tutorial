using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] private GameObject rocketShield;
    public bool IsShieldPick;
    public float xValue, yValue;

    private void Start()
    {
        xValue = Random.Range(-7, 7);
        yValue = Random.Range(-4, 4);
    }

    public void ShieldUp(bool state)
    {
        GameObject tempShield = Instantiate(rocketShield, new Vector2(xValue, yValue), Quaternion.identity);
    }
}
