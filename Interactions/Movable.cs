using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Movable : InteractableObject
{
    private Transform _interactPoint;
    private Rigidbody _rigidbody;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private bool _moveNow;
    private float _speed;
    private Vector3 _difference;
    private Camera _camera;

    private int _throwStrange = 550;

    public void Throw()
    {
        Vector3 direction = (transform.position - _camera.transform.position).normalized;

        _rigidbody.AddForce(direction * _throwStrange);
    }

    private void Start()
    {
        _interactPoint = FindObjectOfType<InteractPoint>().transform;
        _rigidbody = GetComponent<Rigidbody>();

        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        StartCoroutine(SDelay());
    }

    private IEnumerator SDelay()
    {
        yield return new WaitForSeconds(0.5f);
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    public override void Interact()
    {
        if (IsVisible())
        {
            transform.SetParent(_interactPoint);
            _rigidbody.isKinematic = true;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            _moveNow = true;
            StartCoroutine(SpeedDelay());
        }
    }

    public override void StopInteract()
    {
        transform.SetParent(null);
        _rigidbody.isKinematic = false;
        _rigidbody.constraints = RigidbodyConstraints.None;

        _moveNow = false;

        _rigidbody.AddForce(_difference.normalized * _speed * 350);
    }

    public virtual void ResetPosition()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private IEnumerator SpeedDelay()
    {
        Vector3 oldPos = transform.position;
        yield return new WaitForSeconds(0.1f);
        Vector3 newpos = transform.position;

        _difference = newpos - oldPos;

        _speed = Mathf.Abs(_difference.x + _difference.y + _difference.z);

        if (_moveNow)
            StartCoroutine(SpeedDelay());
    }

    private bool IsVisible()
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        var point = gameObject.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }

        return true;
    }
}
