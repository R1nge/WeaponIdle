using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 1)]
public class WeaponSO : ScriptableObject
{
    public Data data;
    public Sprite sprite;

    public void Init()
    {
        data.weaponBaseIncome *= data.weaponLevel;
        data.weaponPrice = (data.weaponBaseIncome * 2 + data.weaponLevel * 10) * 1.2f;
    }

    private void OnEnable() => Load(this);

    private void Load(WeaponSO so)
    {
        data.weaponName = so.data.weaponName;
        data.weaponLevel = so.data.weaponLevel;
        data.weaponPrice = so.data.weaponPrice;
        data.weaponBaseIncome = so.data.weaponBaseIncome;
        data.delay = so.data.delay;
        data.isUnlocked = so.data.isUnlocked;
        data.isAuto = so.data.isAuto;
    }

    public void UpgradeWeapon()
    {
        data.weaponLevel += 1;
        data.weaponBaseIncome *= data.weaponLevel;
        data.weaponPrice = (data.weaponBaseIncome * 2 + data.weaponLevel * 10) * 1.25f;

        if (data.weaponLevel >= 100)
        {
            data.isAuto = true;
        }
    }

    [Serializable]
    public class Data
    {
        public string weaponName;
        public int weaponLevel;
        public float weaponPrice;
        public float weaponBaseIncome;
        public float delay;
        public bool isUnlocked;
        public bool isAuto;
    }
}