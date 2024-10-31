using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    [SerializeField] private int goldAmount = 50;

    public override void Use(PickUpItem pui)
    {
        if (GoldUI.Instance != null)
        {
            GoldUI.Instance.AddGold(goldAmount);
            Debug.Log($"Or ramassé ! Quantité d'or ajoutée : {goldAmount}");
        }

        base.Use(pui);
    }
}




