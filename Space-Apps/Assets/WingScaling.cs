using UnityEngine;

public class WingScaling : MonoBehaviour
{
    void Update()
    {
        transform.localScale = MenuScript.wingScale;
    }
}
