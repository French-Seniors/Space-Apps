using UnityEngine;

public class FuelScaling : MonoBehaviour
{
    void Update()
    {
        transform.localScale = MenuScript.fuelScale;
    }
}
