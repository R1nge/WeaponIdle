using System.Globalization;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins, gems;
    private Wallet _wallet;

    private void Awake()
    {
        Weapon.boost = false;
        _wallet = FindObjectOfType<Wallet>();
        _wallet.OnCoinsAmountChanged += UpdateCoinsText;
        _wallet.OnGemsAmountChanged += UpdateGemsText;
    }
    
    public void ApplyBoost() => Weapon.boost = true;

    private void UpdateCoinsText(float amount) => coins.text = "Coins: " + amount.ToString(CultureInfo.InvariantCulture);

    private void UpdateGemsText(float amount) => gems.text = "Gems: " + amount.ToString(CultureInfo.InvariantCulture);

    private void OnDestroy()
    {
        _wallet.OnCoinsAmountChanged -= UpdateCoinsText;
        _wallet.OnGemsAmountChanged -= UpdateGemsText;
    }
}