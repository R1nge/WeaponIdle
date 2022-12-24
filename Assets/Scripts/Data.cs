using System;
using UnityEngine;

[Serializable]
public class Data
{
    [SerializeField] private float startDelay;
    public string weaponName;
    public int weaponLevel;
    public float weaponPrice;
    public float weaponBaseIncome;
    public float delay;
    public bool isUnlocked;
    public bool isAuto;

    private const int IncomeModifier = 2;
    private const int LevelModifier = 10;
    private const float TotalModifier = 1.25f;

    public event Action OnWeaponUnlocked;
    public event Action<float> OnWeaponUpgraded;

    public void Init()
    {
        weaponBaseIncome *= weaponLevel;
        weaponPrice = (weaponBaseIncome * IncomeModifier + weaponLevel * LevelModifier) * TotalModifier;
    }

    public void UpgradeWeapon()
    {
        weaponLevel += 1;
        weaponBaseIncome *= weaponLevel;
        weaponPrice = (weaponBaseIncome * IncomeModifier + weaponLevel * LevelModifier) * TotalModifier;
        delay -= startDelay / 150;

        if (weaponLevel == 100 && !isAuto)
        {
            MakeAuto();
        }

        OnWeaponUpgraded?.Invoke(delay);
    }

    public void UnlockWeapon()
    {
        isUnlocked = true;
        OnWeaponUnlocked?.Invoke();
    }

    public void MakeAuto() => isAuto = true;
}