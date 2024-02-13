using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private GameObject _followingObject;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        transform.position = _followingObject.transform.position + _offset;
    }
}
