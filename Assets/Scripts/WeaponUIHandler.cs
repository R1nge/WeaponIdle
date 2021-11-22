using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponName, weaponLevel, weaponIncome;
    [SerializeField] private Image weaponImage;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Slider progress;
    [SerializeField] private TextMeshProUGUI upgradePrice;
    [SerializeField] private GameObject lockScreen;
    [SerializeField] private Image lockScreenIcon;
    [SerializeField] private TextMeshProUGUI buy;
    private Wallet _wallet;
    private Weapon[] _weapons;


    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
        _weapons = FindObjectsOfType<Weapon>();
    }

    private void Start()
    {
        UpdateWeaponUI();
        if (!weapon.weaponSo.isUnlocked)
        {
            buy.text = weapon.weaponSo.weaponPrice.ToString(CultureInfo.InvariantCulture);
            lockScreenIcon.sprite = weapon.weaponSo.sprite;
        }
        else
        {
            lockScreen.SetActive(false);
        }
    }

    private void Update()
    {
        progress.value = -weapon.time;
    }

    public void UpgradeWeapon()
    {
        if (_wallet.SpendCoins(weapon.weaponSo.weaponPrice))
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
        upgradePrice.text = weapon.weaponSo.weaponPrice.ToString(CultureInfo.CurrentCulture);
    }

    public void ApplyBoost()
    {
        foreach (var weapon in _weapons)
        {
            if (!weapon.boost)
            {
                weapon.boost = true;
                //Show AD
            }
        }
    }

    public void UnlockWeapon()
    {
        if (_wallet.SpendCoins(weapon.weaponSo.weaponPrice))
        {
            weapon.weaponSo.isUnlocked = true;
            lockScreen.SetActive(false);
        }
    }
}