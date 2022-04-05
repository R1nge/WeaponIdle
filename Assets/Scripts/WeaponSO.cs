using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 1)]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public int weaponLevel;
    public float weaponPrice;
    public float weaponBaseIncome;
    public float weaponIncome;
    public Sprite sprite;
    public bool isUnlocked;
    public bool isAuto;

    public void UpgradeWeapon()
    {
        weaponLevel += 1;
        weaponIncome = weaponBaseIncome * weaponLevel;
        weaponPrice = (weaponIncome * 2 + weaponLevel * 10) * 1.25f;
    }
}