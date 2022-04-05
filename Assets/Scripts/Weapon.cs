using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour, IPointerClickHandler
{
    public WeaponSO weaponSo;
    public static bool boost;
    public float time;
    [SerializeField] private float startTime;
    private Wallet _wallet;
    private bool _startedTimer;

    private void Awake() => _wallet = FindObjectOfType<Wallet>();

    private void Update()
    {
        if (weaponSo.isAuto)
        {
            Shoot();
        }
        
        if(!_startedTimer) return;
        
        if (time <= 0)
        {
            time = startTime;
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
            time = startTime;
            yield return new WaitForSeconds(time);
        }
        
        _startedTimer = false;
        Earn();        
    }
}