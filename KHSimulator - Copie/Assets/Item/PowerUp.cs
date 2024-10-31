using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    [SerializeField] private int maxHealthIncrease = 10; 

    public override void Use(PickUpItem pui)
    {
        EntityHealth playerHealth = pui.GetComponent<EntityHealth>();
        if (playerHealth != null)
        {
            playerHealth.SetMaxHealth(playerHealth.MaxHealth + maxHealthIncrease); 
            Debug.Log($"PowerUp utilis� ! Vie maximale augment�e de : {maxHealthIncrease}");
        }

        base.Use(pui);
    }
}

