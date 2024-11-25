using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathScreenUI;
    private bool isDead = false;

    // ������ � ����� � ������� �����������
    private void Start()
    {
        // ��������, ��� ����� ������ �������� � ������ ����
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
        // ���� ����� �������� ������� � ����� DeathZone
        if (other.gameObject.CompareTag("DeathZone"))
            Dead();
    }

    private void Dead()
    {
        // ���������� ����� � �������� ����� ������
        Time.timeScale = 0f;
        if (deathScreenUI != null)
        {
            deathScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
        }
        isDead = true;
    }

    // ����� ��� ����������� ������
    public void RestartLevel()
    {
        Time.timeScale = 1f; // ���������� ����� � ���������� ���������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ������������ ������� �����
        isDead = false;
    }

    public bool IsPlayerDead() => isDead;
}

