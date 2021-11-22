using UnityEngine;

public class Wallet : MonoBehaviour
{
    public float coins, gems;
    private UIHandler _uiHandler;

    private void Awake()
    {
        _uiHandler = FindObjectOfType<UIHandler>();
        LoadGame();
    }

    public bool SpendCoins(float amount)
    {
        if (coins - amount > 0)
        {
            coins -= amount;
            _uiHandler.UpdateUI();
            return true;
        }

        return false;
    }

    public void EarnCoins(float amount)
    {
        coins += amount;
        _uiHandler.UpdateUI();
        SaveGame();
    }


    private void SaveGame()
    {
        PlayerPrefs.SetFloat("Coins", coins);
    }

    private void LoadGame()
    {
        coins = PlayerPrefs.GetFloat("Coins", coins);
    }
}