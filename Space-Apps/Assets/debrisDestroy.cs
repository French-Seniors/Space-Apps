using UnityEngine;

public class DebrisCleanup : MonoBehaviour
{
    void Update()
    {
        // Adjust -10f based on where the bottom of your camera is
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}