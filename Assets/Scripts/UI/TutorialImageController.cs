using UnityEngine;

public class TutorialImageController : MonoBehaviour
{
    public GameObject tutorialImage; // Перетащите сюда объект Image из Canvas через Inspector
    private bool isTutorialVisible = false;

    void Update()
    {
        // Закрыть изображение по нажатию Escape
        if (isTutorialVisible && Input.GetKeyDown(KeyCode.Escape))
        {
            HideTutorial();
        }
    }

    // Метод для показа изображения
    public void ShowTutorial()
    {
        if (tutorialImage != null)
        {
            tutorialImage.SetActive(true); // Показываем картинку
            isTutorialVisible = true;
            Time.timeScale = 0f; // Останавливаем игру, если нужно
        }
        else
        {
            Debug.LogWarning("Tutorial Image is not assigned.");
        }
    }

    // Метод для скрытия изображения
    public void HideTutorial()
    {
        if (tutorialImage != null)
        {
            tutorialImage.SetActive(false); // Скрываем картинку
            isTutorialVisible = false;
            Time.timeScale = 1f; // Возвращаем время в нормальное состояние
        }
    }
}

