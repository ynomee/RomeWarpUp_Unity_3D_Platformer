using UnityEngine;

public class StartPlatformTrigger : MonoBehaviour
{
    [SerializeField] private LavaChase lavaChase;
    public AudioSource audioSource;
    public float targetVolume = 0.1f;
    public float fadeDuration; //Время нарастания 

    private float startVolume = 0.001f;
    private float currentTime = 0.0f;
    private bool isPlayerTriggered = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = startVolume;    
    }

    private void Update()
    {
        if (isPlayerTriggered)
        {
            if (currentTime < fadeDuration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / fadeDuration);
            }
        }
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Начало преследования!");
            lavaChase.StartChase();
            audioSource.Play();
            isPlayerTriggered = true;
        }
    }
}

