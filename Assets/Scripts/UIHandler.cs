using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins, gems;
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
    }

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        coins.text = "Coins: " + _wallet.coins;
        gems.text = "Gems: " + _wallet.gems;
    }
}