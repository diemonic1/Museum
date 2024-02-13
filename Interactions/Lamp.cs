using UnityEngine;

public class Lamp : InteractableObject
{
    [SerializeField] private GameObject _lightObj;

    public override void Interact()
    {
        _lightObj.SetActive(!_lightObj.activeSelf);
    }
}
