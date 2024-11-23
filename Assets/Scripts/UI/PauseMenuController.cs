using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI; // перетащите сюда Canvas с меню через Inspector
    private bool isPaused = false;

    private PlayerDeath _playerDeath;
    private EndGame _endGame;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        pauseMenuUI.SetActive(false);

        _playerDeath = FindObjectOfType<PlayerDeath>();
        _endGame = FindObjectOfType<EndGame>();
    }

    private void Update()
    {
        InputLogic();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // возобновл€ет игру
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // останавливает игру
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // ¬ернуть врем€ в нормальное состо€ние перед перезагрузкой
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ѕерезагрузить текущую сцену
    }

    public void InputLogic()
    {
        if (_playerDeath != null && _playerDeath.IsPlayerDead() || _endGame != null && _endGame.IsGameWon())
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {   
                Pause();
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit(); // закрывает приложение
        // ¬ редакторе это не будет работать. „тобы протестировать, используйте Debug.Log("Quit Game");
        Debug.Log("Quit Game");
    }
}
