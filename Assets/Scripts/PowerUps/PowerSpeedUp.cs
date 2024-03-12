using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpeedUp : PowerUpBase
{
    [Header("Power Up Speed")]
    public float amountToSpeed;
    public ParticleSystem particles;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.PowerSpeedUp(amountToSpeed);
        PlayerController.Instance.SetPowerUpText("speed up");
    }

    protected virtual void OnCollect()
    {

        if (particleSystem != null)
        {
            if (particles != null) particles.transform.SetParent(null);
            particles.Play();
        }
    }

    // Update is called once per frame
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetSpeed();
        PlayerController.Instance.SetPowerUpText("");
    }
}
