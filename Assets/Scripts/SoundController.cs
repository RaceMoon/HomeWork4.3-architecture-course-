using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private AudioSource _audioSource;
    private BallClicker _ballClicker;

    [Inject] 
    private void Construct(BallClicker ballClicker)
    {
        _ballClicker = ballClicker;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _ballClicker.BallClicked += PlaySound;
    }

    private void OnDisable()
    {
        _ballClicker.BallClicked -= PlaySound;
    }

    private void PlaySound(Ball ball)
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}
