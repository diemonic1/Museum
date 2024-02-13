using UnityEngine;

public class MainDoor : OpenLink
{
    [SerializeField] private GameObject _door;
    [SerializeField] private float _speed;

    [SerializeField] private Quaternion _openRotationQ;
    [SerializeField] private Quaternion _closeRotationQ;

    private bool openned;

    public void Focus()
    {
        openned = true;
    }

    public void Unfocus()
    {
        openned = false;
    }

    private void Update()
    {
        if (openned)
            _door.transform.rotation = Quaternion.Lerp(_door.transform.rotation, _openRotationQ, _speed * Time.deltaTime);
        else
            _door.transform.rotation = Quaternion.Lerp(_door.transform.rotation, _closeRotationQ, _speed * Time.deltaTime);
    }
}
