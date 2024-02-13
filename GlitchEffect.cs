using Kino;
using System.Collections;
using UnityEngine;

public class GlitchEffect : MonoBehaviour
{
    [SerializeField] private float _standartStrength;
    [SerializeField] private float _effectStrengthMin;
    [SerializeField] private float _effectStrengthMax;

    [SerializeField] private float _effectTimeMin;
    [SerializeField] private float _effectTimeMax;

    [SerializeField] private float _effectPauseTimeMin;
    [SerializeField] private float _effectPauseTimeMax;

    [SerializeField] private AnalogGlitch analogGlitch;

    private void Start()
    {
        StartCoroutine(Loop());
    }

    private IEnumerator Loop()
    {
        analogGlitch._scanLineJitter = Random.Range(_effectStrengthMin, _effectStrengthMax);
        yield return new WaitForSeconds(Random.Range(_effectTimeMin, _effectTimeMax));
        analogGlitch._scanLineJitter = _standartStrength;
        yield return new WaitForSeconds(Random.Range(_effectPauseTimeMin, _effectPauseTimeMax));
        StartCoroutine(Loop());
    }
}
