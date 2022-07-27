using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIHandler : MonoBehaviour
{
    private TextMeshProUGUI _weaponName, _weaponLevel, _weaponIncome;
    private Image _weaponImage;
    private Slider _progressBar;
    private TextMeshProUGUI _upgradePrice;
    private GameObject _lockScreen;
    private Image _lockScreenIcon;
    private TextMeshProUGUI _buyPrice;
    private Wallet _wallet;
    private Weapon _weapon;
    
    private void Awake() => FindReferences();

    private void Start()    
    {
        Init();
        UpdateWeaponUI();
    }

    private void Update() => UpdateProgressBar();

    private void FindReferences()
    {
        _wallet = FindObjectOfType<Wallet>();
        _weapon = GetComponent<Weapon>();
        
        //Cringe
        _weaponName = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        _weaponLevel = transform.Find("Level").GetComponent<TextMeshProUGUI>();
        _weaponIncome = transform.Find("Income").GetComponent<TextMeshProUGUI>();
        _weaponImage = transform.Find("Image").GetComponent<Image>();
        _progressBar = transform.Find("Slider").GetComponent<Slider>();
        _upgradePrice = transform.Find("UpgradeButton").GetChild(0).GetComponent<TextMeshProUGUI>();
        _lockScreen = transform.Find("LockScreen").gameObject;
        _lockScreenIcon = _lockScreen.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        _buyPrice = _lockScreen.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }
    
    private void Init()
    {
        if (_weapon.weaponSo.isUnlocked)
        {
            _lockScreen.SetActive(false);
        }
        else
        {
            _buyPrice.text = Helper.FormatNumber(_weapon.weaponSo.weaponPrice);
            _lockScreenIcon.sprite = _weapon.weaponSo.sprite;
        }
        _progressBar.minValue = -_weapon.weaponSo.delay;
        _progressBar.value = _progressBar.minValue;
    }

    private void UpdateProgressBar() => _progressBar.value = -_weapon.time;

    public void UpgradeWeapon()
    {
        if (!_wallet.SpendCoins(_weapon.weaponSo.weaponPrice)) return;
        _weapon.weaponSo.UpgradeWeapon();
        UpdateWeaponUI();
    }

    private void UpdateWeaponUI()
    {
        _weaponName.text = _weapon.weaponSo.weaponName;
        _weaponLevel.text = "Level: " + _weapon.weaponSo.weaponLevel;
        _weaponIncome.text = "Income:" + Helper.FormatNumber(_weapon.weaponSo.weaponBaseIncome);
        _weaponImage.sprite = _weapon.weaponSo.sprite;
        _upgradePrice.text = Helper.FormatNumber(_weapon.weaponSo.weaponPrice);
    }

    public void UnlockWeapon()
    {
        if (!_wallet.SpendCoins(_weapon.weaponSo.weaponPrice)) return;
        _weapon.weaponSo.isUnlocked = true;
        _lockScreen.SetActive(false);
    }
}