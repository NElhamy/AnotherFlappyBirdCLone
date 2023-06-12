using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    public Player player;
    public Text scoreText;
    public GameObject gameOver;
    public GameObject playButton;

    public int GetScore()
    {
        return score;
    }

    public void Awake()
    {
        Application.targetFrameRate= 60;
        Pause();
    }

    public void Play()
    {
        
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            if (pipes[i].tag != "Audio")
            {
                Destroy(pipes[i].gameObject);
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {

        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
