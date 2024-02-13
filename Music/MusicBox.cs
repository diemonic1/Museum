using UnityEngine;
using UnityEngine.Audio;

public class MusicBox : InteractableObject
{
    [SerializeField] private GameObject _musicBoxLight;
    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private ParticleSystem _musixBoxNotes;
    [SerializeField] private ParticleSystem _musixBoxNotes2;

    private bool _playing = true;

    public override void Interact()
    {
        _playing = !_playing;
        _musicBoxLight.SetActive(_playing);

        if (!_playing)
        {
            _audioMixer.audioMixer.SetFloat("masterVolume", -80f);
            _musixBoxNotes.Stop();
            _musixBoxNotes2.Stop();
        }
        else
        {
            _audioMixer.audioMixer.SetFloat("masterVolume", 0f);
            _musixBoxNotes.Play();
            _musixBoxNotes2.Play();
        }
    }
}
