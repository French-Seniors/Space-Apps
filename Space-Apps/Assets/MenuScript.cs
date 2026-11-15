using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static float maxFuel = 80f; // +10 per buy, 10M
    public static float energyRegenPerSecond = 5f; // +1 per buy, 10M
    public static float magnetForce = 5f; // +1 per buy, 10M
    public static float money = 150f;

    void Awake()
    {
        maxFuel = 80f;
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
