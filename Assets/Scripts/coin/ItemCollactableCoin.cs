using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin : itemCollactableBase
{
    public Collider2D colider;
    // Start is called before the first frame update
    protected override void OnCollect()
    {
        base.OnCollect();
        itemManager.Instance.AddCoins();
        colider.enabled = false;
    }

}
