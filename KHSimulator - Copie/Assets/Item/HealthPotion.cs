using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] private int healthAmount = 20; 

    public override void Use(PickUpItem pui)
    {
        EntityHealth playerHealth = pui.GetComponent<EntityHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(-healthAmount); 
            Debug.Log($"Potion de vie utilisée ! Santé ajoutée : {healthAmount}");
        }

        base.Use(pui);
    }
}

