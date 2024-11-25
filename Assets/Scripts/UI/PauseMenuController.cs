using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI; // ���������� ���� Canvas � ���� ����� Inspector
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
        Time.timeScale = 1f; // ������������ ����
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // ������������� ����
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // ������� ����� � ���������� ��������� ����� �������������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ������������� ������� �����
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
        Application.Quit(); // ��������� ����������
        // � ��������� ��� �� ����� ��������. ����� ��������������, ����������� Debug.Log("Quit Game");
        Debug.Log("Quit Game");
    }
}
