using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int coins, gems;

    public bool SpendCoins(int amount)
    {
        if (coins - amount > 0)
        {
            coins -= amount;
            return true;
        }

        return false;
    }

    public bool SpendGems(int amount)
    {
        if (gems - amount > 0)
        {
            gems -= amount;
            return true;
        }

        return false;
    }

    public void EarnCoins(int amount)
    {
        coins += amount;
    }

    public void EarnGems(int amount)
    {
        gems += amount;
    }
}