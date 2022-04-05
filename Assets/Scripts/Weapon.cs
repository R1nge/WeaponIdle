using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour, IPointerClickHandler
{
    public WeaponSO weaponSo;
    public static bool boost;
    [HideInInspector] public float time;
    private float _startTime;
    private Wallet _wallet;
    private bool _startedTimer;

    private void Awake() => _wallet = FindObjectOfType<Wallet>();

    private void Start() => _startTime = weaponSo.startTime;

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

    public void OnPointerClick(PointerEventData eventData)
    {
        if(weaponSo.isAuto) return;
        Shoot();
    }
    
    private void Earn() => _wallet.EarnCoins(weaponSo.weaponIncome);

    private void Shoot()
    {
        if (!weaponSo.isUnlocked) return;
        if(_startedTimer) return;
        _startedTimer = true;
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        if (boost)
        {
            time /= 2;
            yield return new WaitForSeconds(time);
        }
        else
        {
            time = _startTime;
            yield return new WaitForSeconds(time);
        }
        
        _startedTimer = false;
        Earn();        
    }
}