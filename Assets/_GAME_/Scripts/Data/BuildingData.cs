using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class BuildingData : MonoBehaviour
{
    public float Health;
    

    [SerializeField] private TextMeshPro _healthText;

    private void Start()
    {
        _healthText.text = Health.ToString();
    }

    private void UpdateHealthText()
    {
        _healthText.text = Health.ToString();
    }

    public void DecreaseHealth(float dmgToTake)
    {
        Health -= dmgToTake;
        UpdateHealthText();
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
