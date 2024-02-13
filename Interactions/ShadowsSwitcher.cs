using UnityEngine;

public class ShadowsSwitcher : InteractableObject
{
    private bool _isShadowsOn = false;

    private void Start()
    {
        QualitySettings.shadows = ShadowQuality.Disable;
    }

    public override void Interact()
    {
        if (_isShadowsOn)
            QualitySettings.shadows = ShadowQuality.Disable;
        else
            QualitySettings.shadows = ShadowQuality.HardOnly;

        _isShadowsOn = !_isShadowsOn;
    }
}
