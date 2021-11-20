using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int coins, gems;

    public void Spend(int currency, int amount)
    {
        if (currency - amount > 0)
        {
            currency -= amount;
        }
    }

    public void Earn(int currency, int amount)
    {
        currency += amount;
    }
}