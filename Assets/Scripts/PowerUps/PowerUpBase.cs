using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : itemCollactableBase
{
    [Header("Power Up")]
    public float duration;
    // Start is called before the first frame update

    protected override void OnCollect()
    {
        base.OnCollect();
        StartPowerUp();
    }
    protected virtual void StartPowerUp()
    {
        Debug.Log("Start power up");
        Invoke(nameof(EndPowerUp), duration);
    }

    // Update is called once per frame
    protected virtual void EndPowerUp()
    {
        Debug.Log("End power up");
    }
}
