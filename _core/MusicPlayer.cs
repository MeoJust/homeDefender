using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] _musicClips;
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _musicClips[Random.Range(0, _musicClips.Length-1)];
        _audioSource.Play();
        _audioSource.loop = true;
    }

    void Update(){
        _audioSource.volume = AudioManager.Instance.MusicVolume;
    }
}
