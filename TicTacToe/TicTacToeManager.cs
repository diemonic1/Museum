using System.Collections;
using System.Text;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TicTacToeManager : MonoBehaviour
{
    [SerializeField] private char _playerChar;
    [SerializeField] private char _aiChar;

    [SerializeField] private int _randomVerOfCleverMove;

    [SerializeField] private TextMeshProUGUI _playText;

    [SerializeField] private GameObject[] _playerCharsInScene;
    [SerializeField] private GameObject[] _aiCharsInScene;

    [SerializeField] private GameObject[] _buttons;

    [SerializeField] private GameObject[] _winLines;

    [SerializeField] private TextMeshPro _restartText;

    private TicTacToeMinimax _ticTacToeMinimax;
    private string _field = "---------";
    private int _turnCount = 0;

    private string _think;
    private string _play;
    private string _playerWin;
    private string _aiWin;
    private string _draw;
    private string _youTurn;

    private void Start()
    {
        ResetGame();
    }

    public void SetLanguage(string think, string play, string playerWin, string aiWin, string draw, string youTurn, string restart)
    {
        this._think = think;
        this._play = play;
        this._playerWin = playerWin;
        this._aiWin = aiWin;
        this._draw = draw;
        this._youTurn = youTurn;

        _playText.text = play;
        _restartText.text = restart;
    }

    public void ResetGame()
    {
        _ticTacToeMinimax = new TicTacToeMinimax(_aiChar, _playerChar, 2);
        _field = "---------";
        _turnCount = 0;
        _playText.text = _play;

        for (int i = 0; i < 9; i++)
        {
            _buttons[i].SetActive(true);
            _playerCharsInScene[i].SetActive(false);
            _aiCharsInScene[i].SetActive(false);
        }
        for (int i = 0; i < 8; i++)
        {
            _winLines[i].SetActive(false);
        }
        for (int i = 0; i < 9; i++)
        {
            _buttons[i].GetComponent<ButtonTicTacToe>().CanInteract = true;
        }
    }

    public void SetSign(int playerIndex)
    {
        _turnCount++;
        _buttons[playerIndex].SetActive(false);
        StringBuilder sb = new StringBuilder(_field);
        sb[playerIndex] = _playerChar;
        _field = sb.ToString();

        for (int i = 0; i < 9; i++)
        {
            _buttons[i].GetComponent<ButtonTicTacToe>().CanInteract = false;
        }

        if (!CheckWinner())
        {
            if (_turnCount > 8)
            {
                _playText.text = _draw;
            }
            else
            {
                _playText.text = _think;

                StartCoroutine(Delay());
            }
        }

        ShowField();
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.75f);

        if (_turnCount < 9)
        {
            _turnCount++;

            int aiIndex = 0;

            if (MakeRandomSolution())
            {
                aiIndex = _ticTacToeMinimax.BestMove(_field);
            }
            else
            {
                List<int> termsList = new List<int>();

                for (int i = 0; i < 9; i++)
                {
                    if (_buttons[i].activeSelf)
                    {
                        termsList.Add(i);
                    }
                }
                aiIndex = termsList[UnityEngine.Random.Range(0, termsList.Count)];
            }

            _buttons[aiIndex].SetActive(false);
            StringBuilder sb = new StringBuilder(_field);
            sb[aiIndex] = _aiChar;
            _field = sb.ToString();
            _playText.text = _youTurn;
        }

        ShowField();

        if (!CheckWinner())
        {
            for (int i = 0; i < 9; i++)
            {
                _buttons[i].GetComponent<ButtonTicTacToe>().CanInteract = true;
            }
        }
    }

    private bool MakeRandomSolution()
    {
        int solution = Random.Range(1, 101);

        if (solution < _randomVerOfCleverMove)
            return true;

        return false;
    }

    private void ShowField()
    {
        for (int i = 0; i < 9; i++)
        {
            if (_field[i] == _playerChar)
            {
                _playerCharsInScene[i].SetActive(true);
            }
            else if (_field[i] == _aiChar)
            {
                _aiCharsInScene[i].SetActive(true);
            }
        }
    }

    private bool CheckWinner()
    {
        StringBuilder field = new StringBuilder(_field);

        if (field[0] == field[1] && field[1] == field[2] && field[2] != '-')
        {
            _winLines[0].SetActive(true);
            ShowWinText(field, 0);
            return true;
        }
        if (field[3] == field[4] && field[4] == field[5] && field[5] != '-')
        {
            _winLines[1].SetActive(true);
            ShowWinText(field, 3);
            return true;
        }
        if (field[6] == field[7] && field[7] == field[8] && field[8] != '-')
        {
            _winLines[2].SetActive(true);
            ShowWinText(field, 6);
            return true;
        }
        if (field[0] == field[3] && field[3] == field[6] && field[6] != '-')
        {
            _winLines[3].SetActive(true);
            ShowWinText(field, 0);
            return true;
        }
        if (field[1] == field[4] && field[4] == field[7] && field[7] != '-')
        {
            _winLines[4].SetActive(true);
            ShowWinText(field, 1);
            return true;
        }
        if (field[2] == field[5] && field[5] == field[8] && field[8] != '-')
        {
            _winLines[5].SetActive(true);
            ShowWinText(field, 2);
            return true;
        }
        if (field[0] == field[4] && field[4] == field[8] && field[8] != '-')
        {
            _winLines[6].SetActive(true);
            ShowWinText(field, 0);
            return true;
        }
        if (field[2] == field[4] && field[4] == field[6] && field[6] != '-')
        {
            _winLines[7].SetActive(true);
            ShowWinText(field, 2);
            return true;
        }

        return false;
    }

    private void ShowWinText(StringBuilder field, int number)
    {
        if (field[number] == _playerChar)
            _playText.text = _playerWin;
        else
            _playText.text = _aiWin;
    }
}
