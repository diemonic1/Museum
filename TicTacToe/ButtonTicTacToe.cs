using UnityEngine;

public class ButtonTicTacToe : InteractableObject
{
    public bool CanInteract = true;

    [SerializeField] private bool _resetGameButton;
    [SerializeField] private int _index;

    private TicTacToeManager ticTacToeManager;

    private void Start()
    {
        ticTacToeManager = FindObjectOfType<TicTacToeManager>();
    }

    public override void Interact()
    {
        if (CanInteract) {
            if (_resetGameButton)
                ticTacToeManager.ResetGame();
            else
                ticTacToeManager.SetSign(_index);
        }
    }
}
