using UnityEngine;

public class Fire : InteractableObject
{
    [SerializeField] private GameObject lightBase;

    public override void Interact()
    {
        lightBase.SetActive(!lightBase.activeSelf);
    }

    public bool IsFireActive()
    {
        return lightBase.activeSelf;
    }
}
