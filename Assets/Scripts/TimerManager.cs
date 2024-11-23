using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private GameObject _timerObj;
    [SerializeField] private TextMeshProUGUI _timeText;

    private float _startTime;
    private float _currentTime;
    private bool _timerActive;


    private void Start()
    {
        _timerObj.SetActive(false);
    }

    private void Update()
    {
        if (_timerActive)
        {
            _currentTime = Time.time - _startTime;
            _timeText.text = FormatTime(_currentTime);
        }
    }

    private void StartTimer()
    {
        _startTime = Time.time;
        _timerActive = true;
        _timerObj.SetActive(true);
    }

    private void StopTimer()
    {
        _timerActive = false;
        _timerObj.SetActive(true);

        float finalTime = _currentTime;
        _timeText.text = FormatTime(finalTime);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        int milliseconds = Mathf.FloorToInt((time * 1000F) % 1000F);
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("StartLine"))
            {
                StartTimer();
            }
            else if (gameObject.CompareTag("FinishLine"))
            {
                StopTimer();
            }
        }
    }   
}
