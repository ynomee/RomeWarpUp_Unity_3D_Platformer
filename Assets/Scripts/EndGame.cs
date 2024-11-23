using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject winScreenUI;
    private bool isGameWon = false;

    private void Start()
    {
        winScreenUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndLogic();
        }
    }

    private void EndLogic()
    {
        isGameWon = true;
        winScreenUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
    }

    public bool IsGameWon() => isGameWon;
}
