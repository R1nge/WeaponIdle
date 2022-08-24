using System.IO;
using BayatGames.SaveGameFree;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private WeaponSO[] weapons;
    private WeaponSO.Data[] _data;
    private readonly string _identifier = "weapons";

    private void Awake()
    {
        if (SaveGame.Exists(_identifier))
        {
            Load();
        }
        else
        {
            Save();
        }

        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].data = _data[i];
        }
    }

    public void Save()
    {
        _data = new WeaponSO.Data[weapons.Length];

        for (int i = 0; i < weapons.Length; i++)
        {
            _data[i] = weapons[i].data;
        }

        SaveGame.Save(_identifier, _data);
    }

    public void Load()
    {
        _data = SaveGame.Load<WeaponSO.Data[]>(_identifier);

        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].data = _data[i];
        }
    }

    private void OnApplicationQuit() => Save();
}