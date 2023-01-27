using System.Collections.Generic;
using BayatGames.SaveGameFree;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    private Dictionary<string, Data> _dataDictionary;
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
    }

    private void Save()
    {
        _dataDictionary = new Dictionary<string, Data>(weapons.Length);

        for (int i = 0; i < weapons.Length; i++)
        {
            _dataDictionary.Add(weapons[i].data.weaponName, weapons[i].data);
        }

        SaveGame.Save(_identifier, _dataDictionary);
    }

    private void Load()
    {
        _dataDictionary = SaveGame.Load<Dictionary<string, Data>>(_identifier);

        for (int i = 0; i < weapons.Length; i++)
        {
            if (_dataDictionary.TryGetValue(weapons[i].data.weaponName, out Data data))
            {
                weapons[i].data = data;
            }
            else
            {
                Debug.LogError("Key is not found in dictionary", this);
            }
        }
    }

    private void OnApplicationQuit() => Save();
}