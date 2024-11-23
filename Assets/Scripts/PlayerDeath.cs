using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathScreenUI;
    private bool isDead = false;

    // Панель с фоном и кнопкой перезапуска
    private void Start()
    {
        // Убедимся, что экран смерти выключен в начале игры
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(false);
        }
    }

    private void Update()
    {
        Debug.Log(Physics.gravity);
        if (isDead)
            return;
    }

    private void OnTriggerStay(Collider other)
    {
        // Если игрок касается объекта с тегом DeathZone
        if (other.gameObject.CompareTag("DeathZone"))
            Dead();
    }

    private void Dead()
    {
        // Остановить время и показать экран смерти
        Time.timeScale = 0f;
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
        }
        isDead = true;
    }

    // Метод для перезапуска уровня
    public void RestartLevel()
    {
        Time.timeScale = 1f; // Возвращаем время в нормальное состояние
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезагрузка текущей сцены
        isDead = false;
    }

    public bool IsPlayerDead() => isDead;
}

