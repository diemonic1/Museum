using UnityEngine;

[RequireComponent(typeof(Collider))]

public abstract class InteractableObject : MonoBehaviour
{
    public virtual void Interact()
    {

    }

    public virtual void StopInteract()
    {

    }
}
