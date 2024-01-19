using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    public Nader nader;
    public TextMeshProUGUI text;

    private void Start()
    {
        UpdateAmmoText();
    }

    private void Update()
    {
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        text.text = $"{nader.currentAmmoCount} / {nader.maxAmmoCount} | {nader.currentAmmoReserve} / {nader.maxAmmoReserveSize}";
    }
}
