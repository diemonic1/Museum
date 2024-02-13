using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] private float _start = 0;
    [SerializeField] private float _end = 75;
    [SerializeField] private float _offset = 100;
    [SerializeField] private float _smooth = -3;

    private bool _rotateNow;

    public override void Interact()
    {
        _rotateNow = true;
    }


    public override void StopInteract()
    {
        _rotateNow = false;
    }

    private void Update()
    {
        if (_rotateNow)
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * _smooth, 0));
        }

        if (transform.rotation.eulerAngles.y > _end && transform.rotation.eulerAngles.y < _offset)
        {
            transform.rotation = Quaternion.Euler(0, _end, 0);
        }

        if (transform.rotation.eulerAngles.y < _start || (transform.rotation.eulerAngles.y < 360 && transform.rotation.eulerAngles.y > _offset))
        {
            transform.rotation = Quaternion.Euler(0, _start, 0);
        }
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(0, _start, 0);
    }
}
