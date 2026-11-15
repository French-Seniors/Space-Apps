using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static float maxFuel; // +10 per buy, 10M
    public static float energyRegenPerSecond; // +1 per buy, 10M
    public static float magnetForce; // +1 per buy, 10M
    public static float money;

    void Awake()
    {
        maxFuel = 50f;
        energyRegenPerSecond = 5f;
        magnetForce = 5f;
        money = 150f;
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
