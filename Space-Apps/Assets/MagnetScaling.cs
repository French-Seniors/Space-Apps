using UnityEngine;

public class MagnetScaling : MonoBehaviour
{
    void Update()
    {
        transform.localScale = MenuScript.magnetScale;
    }
}
