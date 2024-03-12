using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTimer : MonoBehaviour
{
    public float delayInSeconds = 6.5f; // Adjust this to set the delay before scene transition

    private float timer = 0f;
    private bool timerStarted = false;

    void Update()
    {
        if (!timerStarted)
        {
            timer += Time.deltaTime;
            if (timer >= delayInSeconds)
            {
                timerStarted = true;
                TransitionToPlayScene();
            }
        }
    }

    void TransitionToPlayScene()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
