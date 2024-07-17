using GamePush;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] _musicClips;
    AudioSource _audioSource;

    void OnEnable()
    {
        GP_Game.OnPause += Mute;
        GP_Game.OnResume += UnMute;
    }

    void OnDisable()
    {
        GP_Game.OnPause -= Mute;
        GP_Game.OnResume -= UnMute;
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _musicClips[Random.Range(0, _musicClips.Length - 1)];
        _audioSource.Play();
        _audioSource.loop = true;
    }

    void Update()
    {
        _audioSource.volume = AudioManager.Instance.MusicVolume;
    }

    void Mute() => _audioSource.Pause();

    void UnMute() => _audioSource.UnPause();
}
