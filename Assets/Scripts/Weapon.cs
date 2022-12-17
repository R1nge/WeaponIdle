using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(WeaponUIHandler))]
public class Weapon : MonoBehaviour, IPointerDownHandler
{
    public WeaponSO weaponSo;
    public static bool Boost;
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
            if (Boost)
            {
                WeaponTime -= Time.deltaTime * 2;
            }
            else
            {
                WeaponTime -= Time.deltaTime;
            }
        }
    }

    private async void Shoot()
    {
        if (!weaponSo.data.isUnlocked) return;
        if (_startedTimer) return;
        _startedTimer = true;
        await Delay();
    }

    private async Task Delay()
    {
        await Task.Delay((int)(WeaponTime * 1000));
        Earn();
    }

    private void Earn() => _wallet.EarnCoins(weaponSo.data.weaponBaseIncome);

    public void OnPointerDown(PointerEventData eventData) => Shoot();
}