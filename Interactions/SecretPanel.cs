using System.Collections;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SecretPanel : InteractableObject
{
    [SerializeField] private TextMeshPro _secretPanelText;

    [SerializeField] private string[] _words;

    [SerializeField] private int _maxCountOfChars;

    [SerializeField] private GameObject[] _successes;
    [SerializeField] private GameObject _fail;

    [SerializeField] private FirstPersonController _player;
    [SerializeField] private GameObject _interactPointCanvas;
    [SerializeField] private GameObject _diploma;

    private readonly char[] _keyCodes = new char[] { 'À', 'Á', 'Â', 'Ã', 'Ä', 'Å', '¨', 'Æ', 'Ç', 'È', 'É', 'Ê', 'Ë', 'Ì', 'Í', 'Î', 'Ï', 'Ð', 'Ñ', 'Ò', 'Ó', 'Ô', 'Õ', 'Ö', '×', 'Ø', 'Ù', 'Û', 'Ü', 'Ý', 'Þ', 'ß', 'à', 'á', 'â', 'ã', 'ä', 'å', '¸', 'æ', 'ç', 'è', 'é', 'ê', 'ë', 'ì', 'í', 'î', 'ï', 'ð', 'ñ', 'ò', 'ó', 'ô', 'õ', 'ö', '÷', 'ø', 'ù', 'û', 'ü', 'ý', 'þ', 'ÿ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
    private int _count = 0;
    private bool _interactNow;

    private void Start()
    {
        _secretPanelText.text = "";
    }

    public void ResetPanel()
    {
        if (_successes[0].activeInHierarchy && _successes[1].activeInHierarchy && _successes[2].activeInHierarchy && _successes[3].activeInHierarchy)
        {
            _secretPanelText.text = "";
            _count = 0;

            foreach (GameObject success in _successes)
            {
                success.SetActive(false);
            }

            _fail.SetActive(false);

            GetComponent<SecretPanel>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            _diploma.SetActive(false);
            GetComponent<Animator>().Play("None");
        }
    }

    private void Update()
    {
        if (Input.anyKeyDown && Input.inputString.ToCharArray().Length != 0 && _interactNow) 
        {
            if (_count < _maxCountOfChars)
            {
                char s = Input.inputString.ToCharArray()[0];

                foreach (char c in _keyCodes)
                {
                    if (c == s)
                    {
                        _secretPanelText.text += s;
                        _count++;
                    }
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                _count--;
                _secretPanelText.text = TrimLastCharacter(_secretPanelText.text);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Check(_secretPanelText.text);
                StopInteractWithPanel();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopInteractWithPanel();
        }
    }

    private void StopInteractWithPanel()
    {
        _player.IsConsoleUsing = false;
        _interactNow = false;
        _interactPointCanvas.SetActive(true);
    }

    public override void Interact()
    {
        _player.IsConsoleUsing = true;
        _interactNow = true;
        _interactPointCanvas.SetActive(false);
    }

    private string TrimLastCharacter(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;
        else
            return str.Substring(0, str.Length - 1);
    }

    private bool Check(string text)
    {
        text = text.ToLower();

        for (int i = 0; i < _words.Length; i++)
        {
            if (text == _words[i])
            {
                switch(i)
                {
                    case 0:
                    case 1:
                        _successes[0].SetActive(true);
                        break;
                    case 2:
                    case 3:
                        _successes[1].SetActive(true);
                        break;
                    case 4:
                    case 5:
                        _successes[2].SetActive(true);
                        break;
                    case 6:
                    case 7:
                        _successes[3].SetActive(true);
                        break;
                }

                _secretPanelText.text = "";
                _count = 0;

                if (_successes[0].activeInHierarchy && _successes[1].activeInHierarchy && _successes[2].activeInHierarchy && _successes[3].activeInHierarchy)
                    OpenDoor();

                return true;
            }
        }

        StartCoroutine(FailDelay());
        return false;
    }

    private IEnumerator FailDelay()
    {
        _fail.SetActive(true);

        yield return new WaitForSeconds(2);

        _fail.SetActive(false);
    }

    private void OpenDoor()
    {
        GetComponent<SecretPanel>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        _diploma.SetActive(true);
        GetComponent<Animator>().Play("Open");
    }
}
