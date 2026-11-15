using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static float maxFuel; // +10 per buy, 10M
    public static float energyRegenPerSecond; // +1 per buy, 10M
    public static float magnetForce; // +1 per buy, 10M
    public static float money;
    public static Vector3 wingScale = new Vector3(1f,1f,1f);
    public static Vector3 fuelScale = new Vector3(1f,1f,1f);
    public static Vector3 magnetScale = new Vector3(20f,20f,20f);

    void Awake()
    {
        maxFuel = 50f;
        energyRegenPerSecond = 5f;
        magnetForce = 5f;
        money = 200f;
    }

    public void StartMission()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Application.Quit()");
        Application.Quit();
    }
}
