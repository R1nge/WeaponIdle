using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 1)]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public int weaponLevel;
    public int weaponIncome;
    public Sprite sprite;
    public bool isUnlocked;
}