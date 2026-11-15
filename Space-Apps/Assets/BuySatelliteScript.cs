using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuySatelliteScript : MonoBehaviour
{
    public void StartMission()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
