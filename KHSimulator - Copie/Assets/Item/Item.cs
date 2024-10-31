using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] UnityEvent _destroyFeedback; 

    public virtual void Use(PickUpItem pui)
    {
        Debug.Log($"{name} ramass� !"); 

        _destroyFeedback?.Invoke();

        Destroy(gameObject, 0.5f);
    }
}

