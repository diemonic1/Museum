using UnityEngine;

public class Picture : Movable
{
    [SerializeField] private GameObject Door;

    public override void StopInteract()
    {
        Door.GetComponent<Door>().enabled = true;
        Door.GetComponent<BoxCollider>().enabled = true;

        base.StopInteract();
    }

    public override void ResetPosition()
    {
        Door.GetComponent<Door>().ResetRotation();
        Door.GetComponent<Door>().enabled = false;
        Door.GetComponent<BoxCollider>().enabled = false;

        base.ResetPosition();
    }
}
