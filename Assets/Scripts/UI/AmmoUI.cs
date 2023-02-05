using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]  
public class AmmoUI : MonoBehaviour
{
    public PlayerShooter playerShooter;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        image.fillAmount = playerShooter.GetAmmoPercent();
    }
}
