using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public int weaponLevel;
    public int weaponIncome;
    public Sprite sprite;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
    }

    private void Start()
    {
        Timer.TimeEndEvent += Earn;
    }

    private void Earn()
    {
        _wallet.EarnCoins(weaponIncome);
    }
}