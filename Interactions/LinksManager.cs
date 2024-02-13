using System.Collections;
using UnityEngine;

public class LinksManager : MonoBehaviour
{
    private string[] _links;

    private string _reserve = "https://github.com/diemonic1;https://vk.com/farbeacon;https://www.youtube.com/channel/UC4dg69xVWZ8gejhkN-Z1zNw;https://farbeacon.github.io/Unilovel;https://farbeacon.github.io/LifeBrickGleb;https://farbeacon.github.io/WhenTheStarsCeaseToShine;https://farbeacon.github.io/MementoMori;https://farbeacon.github.io/Vampire;https://farbeacon.github.io/mobileTRIGEO;https://farbeacon.github.io/mobileFlappyDawg;https://farbeacon.github.io/mobileTicTacToe;\r\n0 - github\r\n1 - vk\r\n2 - youtube\r\n3 - unilovel\r\n4 - LifeBrickGleb\r\n5 - WhenTheStarsCeaseToShine\r\n6 - MementoMori\r\n7 - Vampire\r\n8 - mobileTRIGEO\r\n9 - mobileFlappyDawg\r\n10 - mobileTicTacToe";

    private void Start()
    {
        StartCoroutine(Check());
    }

    public string GetLink(int linkNumber)
    {
        return _links[linkNumber];
    }

    private IEnumerator Check()
    {
        WWW data = new WWW("https://farbeacon.github.io/MuseumLinks/links.txt");

        yield return data;

        if (data.error != null)
        {
            _links = _reserve.Split(';');
            Debug.Log("LINKS ERROR!");
        }
        else
        {
            _links = data.text.Split(';');
        }

        PrintLinks();
    }

    private void PrintLinks()
    {
        string result = "";
        int i = 0;

        foreach (string link in _links)
        {
            result += i.ToString() + ": " + link + "\n";
            i++;
        }

        Debug.Log("Links:\n" + result);
    }
}
