using UnityEngine;

public class ShieldSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip startSound;
    [SerializeField] private AudioClip loopSound;
    [SerializeField] private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameplayController.instance.OnGameFinished += Ýnstance_OnGameFinished;
    }

    private void Ýnstance_OnGameFinished()
    {
        audioSource.volume = 0;
    }

    private void OnEnable()
    {
        audioSource.PlayOneShot(startSound);
    }
    // Update is called once per frame
    private void Update()
    {
        if (!audioSource.isPlaying )
        {
            audioSource.clip = loopSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}