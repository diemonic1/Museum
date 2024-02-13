using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LightSwitch : InteractableObject
{
    [SerializeField] private FirstPersonController player;
    [SerializeField] private GameObject _darknessUI;

    private bool _light = true;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (_light)
        {
            _light = false;
            Movable[] movables = FindObjectsOfType<Movable>();

            foreach (Movable movable in movables)
            {
                movable.ResetPosition();
            }

            FindObjectOfType<Picture>().ResetPosition();
            FindObjectOfType<TicTacToeManager>().ResetGame();
            FindObjectOfType<Basket>().SetZero();

            SecretPanel sp = FindObjectOfType<SecretPanel>();
            sp.gameObject.GetComponent<BoxCollider>().enabled = true;
            sp.enabled = true;
            sp.ResetPanel();
            player.light = true;
            _darknessUI.SetActive(true);
        }
        else if (!_light)
        {
            _light = true;
            player.light = false;
            _darknessUI.SetActive(false);
        }

        _audioSource.Play();
    }
}
