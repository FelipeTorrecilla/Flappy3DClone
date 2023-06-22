using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlappyBirdController : MonoBehaviour
{
    public float jumpForce = 300f;
    public Text scoreText;
    public AudioSource jumpAudio;
    public AudioSource gameOverAudio;
    public Rigidbody bird;

    public GameObject gameOverPanel;
    public GameObject pauseMenuPanel;
    public GameObject mainMenuPanel;
    public bool isPaused;

    public int score = 0;
    private bool gameOver = false;

    void Start()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        scoreText.text = "Score: 0";        
    }

    void Update()
    {
        if(isPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
            {
                bird.AddForce(Vector3.up * jumpForce);
                jumpAudio.Play();
            }

            if (Input.GetMouseButtonDown(0) && !gameOver)
            {
                bird.AddForce(Vector3.up * jumpForce);
                jumpAudio.Play();
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !gameOver)
            {
                bird.AddForce(Vector3.up * jumpForce);
                jumpAudio.Play();
            }
        }
        if(gameOver == false)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(isPaused)
                {
                ResumeGame();
                }
                else
                {
                PauseGame();
                }
            }
        }       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            gameOverAudio.Play();
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void StartGame()
    {
        scoreText.text = "Score: 0";
        pauseMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}