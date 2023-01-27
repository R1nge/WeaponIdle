using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeUI : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
        _wallet.OnCoinsAmountChanged += UpdateUI;
        weapon.data.OnWeaponUnlocked += UpdateUI;
        UpdateUI();
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
        text.text = weapon.data.isAuto ? "Unlocked" : $"{price}";
    }

    private void UpdateUI(float money)
    {
        if (!weapon.data.isUnlocked) return;
        if (weapon.data.isAuto)
        {
            text.color = Color.black;
        }
        else
        {
            text.color = money < price ? Helper.RedColor() : Helper.GreenColor();
        }
    }

    private void OnDestroy()
    {
        _wallet.OnCoinsAmountChanged -= UpdateUI;
        weapon.data.OnWeaponUnlocked -= UpdateUI;
    }
}