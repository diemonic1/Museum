using TMPro;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    [Header("dusty")]
    [SerializeField] private TextMeshPro _dusty;
    [SerializeField] private string _dustyEN;
    [SerializeField] private string _dustyRU;

    [Header("secret")]
    [SerializeField] private TextMeshPro _secret;
    [SerializeField] private string _secretEN;
    [SerializeField] private string _secretRU;

    [Header("shadows")]
    [SerializeField] private TextMeshPro _shadows;
    [SerializeField] private string _shadowsEN;
    [SerializeField] private string _shadowsRU;

    [Header("welcome")]
    [SerializeField] private TextMeshPro _welcome;
    [SerializeField] private string _welcomeEN;
    [SerializeField] private string _welcomeRU;

    [Header("money")]
    [SerializeField] private TextMeshPro _money;
    [SerializeField] private string _moneyEN;
    [SerializeField] private string _moneyRU;

    [Header("Keys")]
    [SerializeField] private TextMeshPro _keys;
    [SerializeField] private string _keysEN;
    [SerializeField] private string _keysRU;

    [Header("manual")]
    [SerializeField] private TextMeshPro _manual;
    [SerializeField] private string _manualEN;
    [SerializeField] private string _manualRU;
    [SerializeField] private TextMeshPro _description;
    [SerializeField] private string _descriptionEN;
    [SerializeField] private string _descriptionRU;

    [Header("minimax algoritm")]
    [SerializeField] private TextMeshPro _minimax;
    [SerializeField] private string _minimaxEN;
    [SerializeField] private string _minimaxRU;

    [Header("Find all keys")]
    [SerializeField] private TextMeshPro _findAllKeys;
    [SerializeField] private string _findAllKeysEN;
    [SerializeField] private string _findAllKeysRU;

    [Header("крестики нолики")]
    [SerializeField] private string _thinkEN = "Think...";
    [SerializeField] private string _playEN = "Will we play?";
    [SerializeField] private string _playerWinEN = "You won...";
    [SerializeField] private string _aiWinEN = "I won!";
    [SerializeField] private string _drawEN = "Draw...";
    [SerializeField] private string _youTurnEN = "Your move :)";
    [SerializeField] private string _restartEN = "restart";

    [SerializeField] private string _thinkRU = "Думаю...";
    [SerializeField] private string _playRU = "Сыграем?";
    [SerializeField] private string _playerWinRU = "Ты выиграл...";
    [SerializeField] private string _aiWinRU = "Я выиграл!";
    [SerializeField] private string _drawRU = "Ничья...";
    [SerializeField] private string _youTurnRU = "Твой ход :)";
    [SerializeField] private string _restartRU = "заново";

    private void Start()
    {
        Debug.Log("This system is in language: " + Application.systemLanguage);

        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            FindObjectOfType<TicTacToeManager>().SetLanguage(_thinkRU, _playRU, _playerWinRU, _aiWinRU, _drawRU, _youTurnRU, _restartRU);
            _dusty.text = _dustyRU;
            _keys.text = _keysRU;
            _manual.text = _manualRU;
            _description.text = _descriptionRU;
            _welcome.text = _welcomeRU;
            _minimax.text = _minimaxRU;
            _money.text = _moneyRU;
            _findAllKeys.text = _findAllKeysRU;
            _secret.text = _secretRU;
            _shadows.text = _shadowsRU;
        }
        else
        {
            FindObjectOfType<TicTacToeManager>().SetLanguage(_thinkEN, _playEN, _playerWinEN, _aiWinEN, _drawEN, _youTurnEN, _restartEN);
            _dusty.text = _dustyEN;
            _keys.text = _keysEN;
            _manual.text = _manualEN;
            _description.text = _descriptionEN;
            _welcome.text = _welcomeEN;
            _minimax.text = _minimaxEN;
            _money.text = _moneyEN;
            _findAllKeys.text = _findAllKeysEN;
            _secret.text = _secretEN;
            _shadows.text = _shadowsEN;
        }
    }
}
