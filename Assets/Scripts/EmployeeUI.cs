using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeUI : MonoBehaviour
{
    [SerializeField] private Sprite weaponSprite;
    [SerializeField] private Image weaponImage;
    [SerializeField] private int price;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI weaponNameText;
    [SerializeField] private TextMeshProUGUI priceText;
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
        _wallet.OnCoinsAmountChanged += UpdateUI;
        weapon.data.OnWeaponUnlocked += UpdateUI;
        Init();
        UpdateUI();
    }

    private void Init()
    {
        weaponImage.sprite = weaponSprite;
        weaponNameText.text = weapon.data.weaponName;
    }

    public void MakeAuto()
    {
        if (!_wallet.SpendCoins(price)) return;
        weapon.data.MakeAuto();
        UpdateUI();
    }

    private void UpdateUI()
    {
        button.interactable = !weapon.data.isAuto && weapon.data.isUnlocked;
        priceText.text = weapon.data.isAuto ? "Unlocked" : $"{price}";
    }

    private void UpdateUI(float money)
    {
        if (!weapon.data.isUnlocked) return;
        if (weapon.data.isAuto)
        {
            priceText.color = Color.black;
        }
        else
        {
            priceText.color = money < price ? Helper.RedColor() : Helper.GreenColor();
        }
    }

    private void OnDestroy()
    {
        _wallet.OnCoinsAmountChanged -= UpdateUI;
        weapon.data.OnWeaponUnlocked -= UpdateUI;
    }
}