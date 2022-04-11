using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(WeaponUIHandler))]
public class Weapon : MonoBehaviour, IPointerDownHandler
{
    public WeaponSO weaponSo;
    public static bool boost;
    [HideInInspector] public float time;
    private float _startTime;
    private Wallet _wallet;
    private bool _startedTimer;

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
        weaponSo.Init();
    }

    private void Start()
    {
        _startTime = weaponSo.delay;
        time = _startTime;
    }

    private void Update()
    {
        if (weaponSo.isAuto)
        {
            Shoot();
        }
        
        if(!_startedTimer) return;

        if (time <= 0)
        {
            time = _startTime;
            _startedTimer = false;
        }
        else
        {
            if (boost)
            {
                time -= Time.deltaTime * 2;
            }
            else
            {
                time -= Time.deltaTime;
            }
        }
    }

    public void Shoot()
    {
        if (!weaponSo.isUnlocked) return;
        if(_startedTimer) return;
        _startedTimer = true;
        StartCoroutine(Delay_c());
    }

    private IEnumerator Delay_c()
    {
        yield return new  WaitForSeconds(time);
        Earn();        
    }

    private void Earn() => _wallet.EarnCoins(weaponSo.weaponBaseIncome);

    public void OnPointerDown(PointerEventData eventData)
    {
        Shoot();
        print("click");
    }
}