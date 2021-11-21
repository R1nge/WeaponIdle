using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponName, weaponLevel, weaponIncome;
    [SerializeField] private Image weaponImage;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Slider progress;
    private Wallet _wallet;
    private Timer _timer;

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
        _timer = FindObjectOfType<Timer>();
    }

    private void Start()
    {
        UpdateWeaponUI();
    }

    private void Update()
    {
        progress.value = -_timer.time;
    }

    public void UpgradeWeapon()
    {
        if (_wallet.SpendCoins(weapon.weaponSo.weaponLevel * 10))
        {
            weapon.UpgradeWeapon();
            UpdateWeaponUI();
        }
    }

    private void UpdateWeaponUI()
    {
        weaponName.text = weapon.weaponSo.weaponName;
        weaponLevel.text = "Level: " + weapon.weaponSo.weaponLevel;
        weaponIncome.text = "Income:" + weapon.weaponSo.weaponIncome;
        weaponImage.sprite = weapon.weaponSo.sprite;
    }
}