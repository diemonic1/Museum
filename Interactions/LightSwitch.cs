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
            FindObjectOfType<Fire>().TurnOn();

            SecretPanel secretPanel = FindObjectOfType<SecretPanel>();
            secretPanel.gameObject.GetComponent<BoxCollider>().enabled = true;
            secretPanel.enabled = true;
            secretPanel.ResetPanel();

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
