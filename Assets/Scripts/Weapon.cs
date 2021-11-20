using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponSO weaponSo;
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
        Timer.TimeEndEvent += Earn;
    }

    private void Earn()
    {
        if (weaponSo.isUnlocked)
        {
            _wallet.EarnCoins(weaponSo.weaponIncome);
        }
    }

    public void UpgradeWeapon()
    {
        weaponSo.weaponLevel += 1;
        weaponSo.weaponIncome = 2 * weaponSo.weaponLevel;
    }
}