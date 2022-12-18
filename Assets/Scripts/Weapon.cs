using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(WeaponUI))]
public class Weapon : MonoBehaviour, IPointerDownHandler
{
    public Data data;
    public static bool Boost;
    private float _startTime;
    private bool _startedTimer;
    private float _weaponTime;
    private Wallet _wallet;
    private WeaponUI _weaponUI;

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
        _weaponUI = GetComponent<WeaponUI>();
        data.Init();
        data.OnWeaponUpgraded += OnWeaponUpgraded;
    }

    private void OnWeaponUpgraded(float delay)
    {
        _startTime = delay;
        _weaponUI.UpdateProgressBar(delay);
    }

    private void Start()
    {
        _startTime = data.delay;
        _weaponTime = _startTime;
    }

    private void Update()
    {
        if (data.isAuto)
        {
            Shoot();
        }

        if (!_startedTimer) return;

        if (_weaponTime <= 0)
        {
            _weaponTime = _startTime;
            _startedTimer = false;
        }
        else
        {
            if (Boost)
            {
                _weaponTime -= Time.deltaTime * 2;
            }
            else
            {
                _weaponTime -= Time.deltaTime;
            }
        }

        _weaponUI.UpdateProgressBar(_weaponTime);
    }

    private async void Shoot()
    {
        if (!data.isUnlocked) return;
        if (_startedTimer) return;
        _startedTimer = true;
        await Delay();
    }

    private async Task Delay()
    {
        await Task.Delay((int)(_weaponTime * 1000));
        Earn();
    }

    private void Earn() => _wallet.EarnCoins(data.weaponBaseIncome);

    public void OnPointerDown(PointerEventData eventData) => Shoot();

    private void OnDestroy() => data.OnWeaponUpgraded -= OnWeaponUpgraded;
}