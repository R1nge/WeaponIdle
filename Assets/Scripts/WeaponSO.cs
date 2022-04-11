using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 1)]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public int weaponLevel;
    public float weaponPrice;
    public float weaponBaseIncome;
    public float delay;
    public Sprite sprite;
    public bool isUnlocked;
    public bool isAuto;

    public void Init()
    {
        weaponBaseIncome *= weaponLevel;
        weaponPrice = (weaponBaseIncome * 2 + weaponLevel * 10) * 1.2f;
    }
    
    public void UpgradeWeapon()
    {
        weaponLevel += 1;
        weaponBaseIncome *= weaponLevel;
        weaponPrice = (weaponBaseIncome * 2 + weaponLevel * 10) * 1.25f;

        if (weaponLevel >= 100)
        {
            isAuto = true;
        }
    }
}