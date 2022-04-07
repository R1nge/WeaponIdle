using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private float coins, gems;
    private const string Coins = "Coins";
    private const string Gems = "Gems";
    public event Action<float> OnCoinsAmountChanged;
    public event Action<float> OnGemsAmountChanged;

    private void Awake()
    {
        Load();
        OnCoinsAmountChanged += delegate { Save(); };
        OnGemsAmountChanged += delegate { Save(); };
    }

    private void Start()
    {
        OnCoinsAmountChanged?.Invoke(coins);
        OnGemsAmountChanged?.Invoke(gems);
    }

    public void EarnCoins(float amount)
    {
        coins += amount;
        OnCoinsAmountChanged?.Invoke(coins);
    }

    public bool SpendCoins(float amount)
    {
        if (!(coins - amount >= 0)) return false;
        coins -= amount;
        OnCoinsAmountChanged?.Invoke(coins);
        return true;
    }

    public void EarnGems(float amount)
    {
        coins += amount;
        OnGemsAmountChanged?.Invoke(gems);
    }
    
    public bool SpendGems(float amount)
    {
        if (!(coins - amount >= 0)) return false;
        coins -= amount;
        OnGemsAmountChanged?.Invoke(gems);
        return true;
    }
    
    private void Save()
    {
        PlayerPrefs.SetFloat(Coins, coins);
        PlayerPrefs.SetFloat(Gems,gems);
        PlayerPrefs.Save();
    }

    private void Load()
    {
        coins = PlayerPrefs.GetFloat(Coins, coins);
        gems = PlayerPrefs.GetFloat(Gems, gems);
    }
}