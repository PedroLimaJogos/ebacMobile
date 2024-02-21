using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpeedUp : PowerUpBase
{
    [Header("Power Up Speed")]
    public float amountToSpeed;
    // Start is called before the first frame update
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.PowerSpeedUp(amountToSpeed);
        PlayerController.Instance.SetPowerUpText("speed up");
    }

    // Update is called once per frame
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetSpeed();
        PlayerController.Instance.SetPowerUpText("");
    }
}
