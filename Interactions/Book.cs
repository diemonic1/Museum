using UnityEngine;

public class Book : Movable
{
    [SerializeField] private ParticleSystem _smilePaticle;

    private bool _activated;
    private bool _canActivate = true;

    public override void Interact()
    {
        base.Interact();
        _canActivate = false;
    }

    public override void StopInteract()
    {
        base.StopInteract();
        _canActivate = true;
    }

    public override void ResetPosition()
    {
        base.ResetPosition();
        _activated = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Fire>() && other.GetComponent<Fire>().IsFireActive() && !_activated && _canActivate)
        {
            _activated = true;
            _smilePaticle.Play();
        }
    }
}
