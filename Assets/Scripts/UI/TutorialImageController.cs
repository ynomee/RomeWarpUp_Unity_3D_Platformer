using UnityEngine;

public class TutorialImageController : MonoBehaviour
{
    public GameObject tutorialImage; // ���������� ���� ������ Image �� Canvas ����� Inspector
    private bool isTutorialVisible = false;

    void Update()
    {
        // ������� ����������� �� ������� Escape
        if (isTutorialVisible && Input.GetKeyDown(KeyCode.Escape))
        {
            HideTutorial();
        }
    }

    // ����� ��� ������ �����������
    public void ShowTutorial()
    {
        if (tutorialImage != null)
        {
            tutorialImage.SetActive(true); // ���������� ��������
            isTutorialVisible = true;
            Time.timeScale = 0f; // ������������� ����, ���� �����
        }
        else
        {
            Debug.LogWarning("Tutorial Image is not assigned.");
        }
    }

    // ����� ��� ������� �����������
    public void HideTutorial()
    {
        if (tutorialImage != null)
        {
            tutorialImage.SetActive(false); // �������� ��������
            isTutorialVisible = false;
            Time.timeScale = 1f; // ���������� ����� � ���������� ���������
        }
    }
}

