using UnityEngine;

public class Lamp : InteractableObject
{
    [SerializeField] private GameObject _lightObj;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        _lightObj.SetActive(!_lightObj.activeSelf);
        _audioSource.Play();
    }
}
