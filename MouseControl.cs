using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MouseControl : MonoBehaviour
{
    [SerializeField] private FirstPersonController player;
    [SerializeField] private string _escapeAxis;

    private void Start()
    {
        Locked(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetAxis(_escapeAxis) > 0)
            Locked(false);
        else if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            Locked(true);
    }

    private void Locked(bool mode)
    {
        if (mode)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;

        Cursor.visible = !mode;
        player.BlockCursor = !mode;
    }
}
