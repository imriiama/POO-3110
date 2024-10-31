using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEntity : MonoBehaviour
{
    [SerializeField] private int damage = 10;           
    [SerializeField] private float activeDuration = 2f;
    [SerializeField] private float inactiveDuration = 3f; 
    [SerializeField] public Collider dangerCollider;   

    private void Start()
    {
        StartCoroutine(CycleZone());
    }

    private IEnumerator CycleZone()
    {
        while (true)
        {
            dangerCollider.enabled = true;
            //Debug.Log("DangerZone active");
            yield return new WaitForSeconds(activeDuration);

            dangerCollider.enabled = false;
            //Debug.Log("DangerZone inactive");
            yield return new WaitForSeconds(inactiveDuration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dangerCollider.enabled)
        {
            EntityHealth playerHealth = other.GetComponent<EntityHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Le joueur prend des dégâts de la DangerZone !");
            }
        }
    }
}

