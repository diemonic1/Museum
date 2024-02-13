using System.Collections;
using UnityEngine;

public class OpenLink : InteractableObject
{
    private enum number
    {
        github = 0,
        vk = 1,
        youtube = 2,
        unilovel = 3,
        LifeBrickGleb = 4,
        WhenTheStarsCeaseToShine = 5,
        MementoMori = 6,
        Vampire = 7,
        mobileTRIGEO = 8,
        mobileFlappyDawg = 9,
        mobileTicTacToe = 10,
        mainSite = 11,
        itchio = 12
    }

    [SerializeField] private number _linkType;

    private string _webLink;
    private bool _wasPressed;

    private void Start()
    {
        StartCoroutine(StartDelay());
    }

    public override void Interact()
    {
        if (!_wasPressed)
        {
            _wasPressed = true;
            Application.OpenURL(_webLink);
            Debug.Log("open link: " + _webLink);
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        _wasPressed = false;
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1.5f);
        _webLink = FindObjectOfType<LinksManager>().GetLink((int)_linkType);
    }
}
