using System.Collections;
using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private TextMeshPro _scoreText;
    [SerializeField] private Transform _interactPoint;
    [SerializeField] private int _scoreToFirework;
    [SerializeField] private ParticleSystem _firework;
    [SerializeField] private float _time;

    private int _score = 0;
    private bool _canTouchdown = true;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Delay());
        if (_interactPoint.childCount == 0 && _canTouchdown && other.gameObject.GetComponent<Rigidbody>().velocity.y < 0)
        {
            _canTouchdown = false;
            _score++;
            _scoreText.text = _score.ToString();

            if (_score % _scoreToFirework == 0)
                _firework.Play();
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_time);
        _canTouchdown = true;
    }

    public void SetZero()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }
}
