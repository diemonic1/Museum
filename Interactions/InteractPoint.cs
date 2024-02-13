using UnityEngine;

public class InteractPoint : MonoBehaviour
{
    [SerializeField] private float _rayLength = 2.2f;
    [SerializeField] private float _rotateSpeed = 3000;

    [SerializeField] private string _layerMaskName = "Interact";

    [SerializeField] private GameObject _interactPointUI;
    [SerializeField] private GameObject _pointArrowUI;

    [SerializeField] private Transform _rotateVector;

    private bool _canInteract;
    private bool _InteractNow;

    private InteractableObject interactableObject;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, _rayLength, LayerMask.GetMask(_layerMaskName));

        if (hit.collider != null && hit.collider.GetComponent<InteractableObject>() && !_InteractNow)
        {
            if (hit.collider.GetComponent<Movable>())
                interactableObject = hit.collider.GetComponent<Movable>();
            else
                interactableObject = hit.collider.GetComponent<InteractableObject>();

            _interactPointUI.SetActive(true);

            if (hit.collider.GetComponent<OpenLink>())
                _pointArrowUI.SetActive(true);

            _canInteract = true;

            if (interactableObject is MainDoor)
            {
                _pointArrowUI.SetActive(true);
                interactableObject.GetComponent<MainDoor>().Focus();
            } 
        }
        else
        {
            _interactPointUI.SetActive(false);
            _canInteract = false;

            _pointArrowUI.SetActive(false);

            if (interactableObject is MainDoor)
                interactableObject.GetComponent<MainDoor>().Unfocus();
        }

        if (_InteractNow && (interactableObject is Movable))
        {
            Transform currentTransform = interactableObject.gameObject.transform;
            currentTransform.Rotate(_rotateVector.forward * _rotateSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel"), Space.World);
        }

        if (_canInteract && !_InteractNow && Input.GetButtonDown("Fire1"))
        {
            interactableObject.Interact();
            _InteractNow = true;
        }
        else if (_InteractNow && Input.GetButtonUp("Fire1"))
        {
            ResetIneraction();
        }
        else if (_InteractNow && Input.GetButtonUp("Fire2") && interactableObject is Movable)
        {
            ResetIneraction();
        }
    }

    private void ResetIneraction()
    {
        interactableObject.StopInteract();

        if (interactableObject is Movable)
            interactableObject.GetComponent<Movable>().Throw();

        _InteractNow = false;
        interactableObject = null;
    }
}
