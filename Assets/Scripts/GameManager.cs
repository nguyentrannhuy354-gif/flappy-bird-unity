using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;
    private PlayerControls controls;

    public enum GameState
    {
        Start,
        Playing,
        GameOver
    }
    public GameState currentState;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private PipeSpawner pipeSpawner;
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI finalScore;


    private void Awake()
    {
        controls = new PlayerControls();

    }

    private void Start()
    {
        currentState = GameState.Start;
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        pipeSpawner.enabled = false;
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Gamelay.Restart.performed += OnRestart;
    }

    private void OnDisable()
    {
        controls.Disable();
        controls.Gamelay.Restart.performed -= OnRestart;
    }

    private void OnRestart(InputAction.CallbackContext context)
    {
        if (currentState == GameState.GameOver)
        {
            RestartGame();
        }
    }


    public void startGame()
    {
        currentState = GameState.Playing;
        startPanel.SetActive(false);
        pipeSpawner.enabled = true;

        player.StartGame();
    }
    public void AddScore()
    {
        score++;
        scoreText.text = $"Score: {score.ToString()}";
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        resetGame();
    }

    public void GameOver()
    {

        Time.timeScale = 0f;
        currentState = GameState.GameOver;
        gameOverPanel.SetActive(true);

        finalScore.text = $"Score: {score}\n Press Space to restart";
    }

    public void resetGame()
    {
        currentState = GameState.Playing;
        player.resetPlayer();

        //xoa het nhung pipe hien co
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject item in pipes)
            Destroy(item);

        score = 0;
        scoreText.text = "Score: 0";

        gameOverPanel.SetActive(false);
        startPanel.SetActive(false);

        pipeSpawner.CancelInvoke();
        pipeSpawner.Start();
    }
}
