using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins, gems;
    [SerializeField] private TextMeshProUGUI weaponName, weaponLevel, weaponIncome;
    [SerializeField] private Image weaponImage;
    [SerializeField] private GameObject upgradeMenu;
    private Weapon _weapon;
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
    }

    private void Start()
    {
        UpdateUI();
        Timer.TimeEndEvent += UpdateUI;
    }

    public void ShowUpgradeMenu(Weapon weapon)
    {
        upgradeMenu.SetActive(true);
        _weapon = weapon;
        UpdateUpgradeUI();
    }

    public void UpgradeWeapon()
    {
        if (_wallet.SpendCoins(_weapon.weaponSo.weaponLevel * 10))
        {
            _weapon.UpgradeWeapon();
            UpdateUpgradeUI();
            UpdateUI();
        }
    }

    public void HideUpgradeMenu()
    {
        upgradeMenu.SetActive(false);
    }

    private void UpdateUI()
    {
        coins.text = "Coins: " + _wallet.coins;
        gems.text = "Gems: " + _wallet.gems;
    }

    private void UpdateUpgradeUI()
    {
        weaponName.text = _weapon.weaponSo.weaponName;
        weaponLevel.text = "Level: " + _weapon.weaponSo.weaponLevel;
        weaponIncome.text = "Income:" + _weapon.weaponSo.weaponIncome;
        weaponImage.sprite = _weapon.weaponSo.sprite;
    }
}