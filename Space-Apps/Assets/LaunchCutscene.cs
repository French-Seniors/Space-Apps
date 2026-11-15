using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LaunchCutscene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    void Start()
    {
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
