using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] public Sprite sprite;
    [SerializeField] private TextMeshProUGUI weaponName, weaponLevel, weaponIncome;
    [SerializeField] private Image weaponImage;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI upgradePrice;
    [SerializeField] private GameObject lockScreen;
    [SerializeField] private Image lockScreenIcon;
    [SerializeField] private TextMeshProUGUI buyPrice;
    private Wallet _wallet;
    private Weapon _weapon;

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
        _weapon = GetComponent<Weapon>();
        _wallet.OnCoinsAmountChanged += UpdateWeaponUI;
    }

    private void UpdateWeaponUI(float money)
    {
        upgradePrice.color = money < _weapon.data.weaponPrice ? Helper.RedColor() : Helper.GreenColor();
    }

    private void Start()
    {
        Init();
        UpdateWeaponUI();
    }

    private void Init()
    {
        if (_weapon.data.isUnlocked)
        {
            lockScreen.SetActive(false);
        }
        else
        {
            buyPrice.text = Helper.FormatNumber(_weapon.data.weaponPrice);
            lockScreenIcon.sprite = sprite;
        }

        progressBar.minValue = -_weapon.data.delay;
        progressBar.value = progressBar.minValue;
    }

    public void UpdateProgressBar(float value) => progressBar.value = -value;

    private void UpdateWeaponUI()
    {
        weaponName.text = _weapon.data.weaponName;
        weaponLevel.text = "Level: " + _weapon.data.weaponLevel;
        weaponIncome.text = "Income:" + Helper.FormatNumber(_weapon.data.weaponBaseIncome);
        weaponImage.sprite = sprite;
        upgradePrice.text = Helper.FormatNumber(_weapon.data.weaponPrice);
        progressBar.minValue = -_weapon.data.delay;
    }

    public void UpgradeWeapon()
    {
        if (!_wallet.SpendCoins(_weapon.data.weaponPrice)) return;
        _weapon.data.UpgradeWeapon();
        UpdateWeaponUI();
    }

    public void UnlockWeapon()
    {
        if (!_wallet.SpendCoins(_weapon.data.weaponPrice)) return;
        _weapon.data.UnlockWeapon();
        lockScreen.SetActive(false);
    }
}