using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int coins, gems;
    private UIHandler _uiHandler;

    private void Awake()
    {
        _uiHandler = FindObjectOfType<UIHandler>();
        LoadGame();
    }

    public bool SpendCoins(int amount)
    {
        if (coins - amount > 0)
        {
            coins -= amount;
            _uiHandler.UpdateUI();
            return true;
        }

        return false;
    }

    public bool SpendGems(int amount)
    {
        if (gems - amount > 0)
        {
            gems -= amount;
            _uiHandler.UpdateUI();
            return true;
        }

        return false;
    }

    public void EarnCoins(int amount)
    {
        coins += amount;
        _uiHandler.UpdateUI();
        SaveGame();
    }

    public void EarnGems(int amount)
    {
        gems += amount;
        _uiHandler.UpdateUI();
    }

    private void SaveGame()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Gems", gems);
    }

    private void LoadGame()
    {
        coins = PlayerPrefs.GetInt("Coins", coins);
        gems = PlayerPrefs.GetInt("Gems", gems);
    }
}