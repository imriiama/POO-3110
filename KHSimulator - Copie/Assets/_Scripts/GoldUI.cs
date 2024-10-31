using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    public static GoldUI Instance { get; private set; } 
    [SerializeField] private TextMeshProUGUI goldText;
    private int goldAmount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        UpdateGoldUI();
    }

    public void AddGold(int amount)
    {
        goldAmount += amount;
        UpdateGoldUI();
        Debug.Log($"Or ajouté : {amount}. Total : {goldAmount}");
    }

    private void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + goldAmount;
        }
    }
}





