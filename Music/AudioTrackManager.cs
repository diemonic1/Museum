using TMPro;
using UnityEngine;

public class AudioTrackManager : InteractableObject
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _otherClips;

    [SerializeField] private int _currentTrack = 0;

    [SerializeField] private TextMeshPro _currentTrackText;

    private int _trackCount;

    private void Start()
    {
        _trackCount = _otherClips.Length;
        _currentTrackText.text = _otherClips[_currentTrack].name;
        _audioSource.clip = _otherClips[_currentTrack];
        _audioSource.Play();
    }

    private void Update()
    {
        if (_audioSource.clip.length - _audioSource.time <= 0)
        {
            NextTrack();
        }
    }

    public override void Interact()
    {
        _audioSource.Stop();
        NextTrack();
    }

    private void NextTrack()
    {
        _currentTrack++;

        if (_currentTrack == _trackCount)
            _currentTrack = 0;

        _currentTrackText.text = _otherClips[_currentTrack].name;
        _audioSource.clip = _otherClips[_currentTrack];

        _audioSource.Play();
    }
}
