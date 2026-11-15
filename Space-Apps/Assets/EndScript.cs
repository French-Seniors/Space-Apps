using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScript : MonoBehaviour
{
    public TMP_Text count;
    public TMP_Text percent;
    public void StartMission()
    {
        SceneManager.LoadScene(2);
    }

    void Start()
    {
        count.text = $"{ResourceManager.finalCount} SPACE DEBRIS COLLECTED";
        percent.text = $"{ResourceManager.finalCount/500}% OF SPACE DEBRIS CLEARED";
        MenuScript.money += ResourceManager.finalCount*10f;
        MenuScript.totalCleared += ResourceManager.finalCount;
    }
}
