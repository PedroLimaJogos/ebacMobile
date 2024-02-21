using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase
{
    [Header("Power Up Speed")]
    public float amountToSpeed;
    // Start is called before the first frame update
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetInvencible();
        PlayerController.Instance.SetPowerUpText("Invencible");
    }

    // Update is called once per frame
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetInvencible(false);
        PlayerController.Instance.SetPowerUpText("");
    }
}
