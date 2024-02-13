using UnityEngine;

public class Cat : InteractableObject
{
    private ParticleSystem _catPaticle;

    private void Start()
    {
        _catPaticle = GetComponent<ParticleSystem>();
    }

    public override void Interact()
    {
        _catPaticle.Play();
    }
}
