using UnityEngine;

public class Audio : MonoBehaviour
{
    private static Audio instance;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}