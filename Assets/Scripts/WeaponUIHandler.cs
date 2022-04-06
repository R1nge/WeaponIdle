using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponName, weaponLevel, weaponIncome;
    [SerializeField] private Image weaponImage;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI upgradePrice;
    [SerializeField] private GameObject lockScreen;
    [SerializeField] private Image lockScreenIcon;
    [SerializeField] private TextMeshProUGUI buy;
    private Wallet _wallet;
    private Weapon _weapon;
    
    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
        _weapon = GetComponent<Weapon>();
    }

    private void Start()    
    {
        Init();
        UpdateWeaponUI();
    }

    private void Update() => UpdateProgressBar();

    private void Init()
    {
        if (_weapon.weaponSo.isUnlocked)
        {
            lockScreen.SetActive(false);
        }
        else
        {
            buy.text = _weapon.weaponSo.weaponPrice.ToString(CultureInfo.InvariantCulture);
            lockScreenIcon.sprite = _weapon.weaponSo.sprite;
        }

        progressBar.minValue = -_weapon.weaponSo.startTime;
        progressBar.value = progressBar.minValue;
    }

    private void UpdateProgressBar() => progressBar.value = -_weapon.time;

    public void UpgradeWeapon()
    {
        if (!_wallet.SpendCoins(_weapon.weaponSo.weaponPrice)) return;
        _weapon.weaponSo.UpgradeWeapon();
        UpdateWeaponUI();
    }

    private void UpdateWeaponUI()
    {
        weaponName.text = _weapon.weaponSo.weaponName;
        weaponLevel.text = "Level: " + _weapon.weaponSo.weaponLevel;
        weaponIncome.text = "Income:" + _weapon.weaponSo.weaponIncome;
        weaponImage.sprite = _weapon.weaponSo.sprite;
        upgradePrice.text = _weapon.weaponSo.weaponPrice.ToString(CultureInfo.CurrentCulture);
    }

    public void UnlockWeapon()
    {
        if (!_wallet.SpendCoins(_weapon.weaponSo.weaponPrice)) return;
        _weapon.weaponSo.isUnlocked = true;
        lockScreen.SetActive(false);
    }
}