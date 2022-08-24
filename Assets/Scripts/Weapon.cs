using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(WeaponUIHandler))]
public class Weapon : MonoBehaviour, IPointerDownHandler
{
    public WeaponSO weaponSo;
    public static bool boost;
    private float _startTime;
    private Wallet _wallet;
    private bool _startedTimer;

    public float WeaponTime { get; private set; }

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
        weaponSo.Init();
    }

    private void Start()
    {
        _startTime = weaponSo.data.delay;
        WeaponTime = _startTime;
    }

    private void Update()
    {
        if (weaponSo.data.isAuto)
        {
            Shoot();
        }

        if (!_startedTimer) return;

        if (WeaponTime <= 0)
        {
            WeaponTime = _startTime;
            _startedTimer = false;
        }
        else
        {
            if (boost)
            {
                WeaponTime -= Time.deltaTime * 2;
            }
            else
            {
                WeaponTime -= Time.deltaTime;
            }
        }
    }

    private void Shoot()
    {
        if (!weaponSo.data.isUnlocked) return;
        if (_startedTimer) return;
        _startedTimer = true;
        StartCoroutine(Delay_c());
    }

    private IEnumerator Delay_c()
    {
        yield return new WaitForSeconds(WeaponTime);
        Earn();
    }

    private void Earn() => _wallet.EarnCoins(weaponSo.data.weaponBaseIncome);

    public void OnPointerDown(PointerEventData eventData) => Shoot();
}