using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponSO weaponSo;
    public static bool boost;
    [HideInInspector] public float time;
    private float _startTime;
    private Wallet _wallet;
    private bool _startedTimer;

    private void Awake() => _wallet = FindObjectOfType<Wallet>();

    private void Start()
    {
        _startTime = weaponSo.startTime;
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
        }
        else
        {
            time -= Time.deltaTime;
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
        if (boost)
        {
            time /= 2;
        }
        else
        {
            time = _startTime;
        }
        
        yield return new  WaitForSeconds(time);
        
        _startedTimer = false;
        Earn();        
    }

    private void Earn() => _wallet.EarnCoins(weaponSo.weaponIncome);
}