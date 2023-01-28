using System.Globalization;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins, gems;
    [SerializeField] private GameObject mainScreen, employeeScreen, settingsScreen;
    private Wallet _wallet;

    private void Awake()
    {
        ShowMainScreen();
        ShowEmployeeScreen();
        ShowSettingsMenu();
        _wallet = FindObjectOfType<Wallet>();
        _wallet.OnCoinsAmountChanged += UpdateCoinsText;
        _wallet.OnGemsAmountChanged += UpdateGemsText;
    }

    private void Start()
    {
        ShowMainScreen();
    }

    public void ShowMainScreen()
    {
        mainScreen.SetActive(true);
        employeeScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }

    public void ShowEmployeeScreen()
    {
        mainScreen.SetActive(false);
        employeeScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void ShowSettingsMenu()
    {
        mainScreen.SetActive(false);
        employeeScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void ApplyBoost() => Weapon.Boost = true; //TODO: Show Ad

    private void UpdateCoinsText(float amount) =>
        coins.text = "Coins: " + Helper.FormatNumber(amount).ToString(CultureInfo.InvariantCulture);

    private void UpdateGemsText(float amount) => gems.text = "Gems: " + Helper.FormatNumber(amount);

    private void OnDestroy()
    {
        _wallet.OnCoinsAmountChanged -= UpdateCoinsText;
        _wallet.OnGemsAmountChanged -= UpdateGemsText;
    }
}