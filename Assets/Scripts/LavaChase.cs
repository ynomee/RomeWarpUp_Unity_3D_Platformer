using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaChase : MonoBehaviour
{
    public GameObject deathScreen;
    [SerializeField] private GameObject _wildFire;
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 5f;
    private bool _isChasing = false;

    private void Start()
    {
        _wildFire.SetActive(false);
    }

    private void Update()
    {
        if (_isChasing)
        {
            Vector3 direction = (_player.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
        }
    }

    public void StartChase()
    {
        _isChasing = true;
        _wildFire.SetActive(true);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            deathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
            Time.timeScale = 0f;
            Debug.Log("Проебали! Игра окончена!");
        }
    }
}

