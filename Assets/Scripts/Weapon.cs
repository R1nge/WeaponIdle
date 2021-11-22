using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour, IPointerClickHandler
{
    public float time;
    public WeaponSO weaponSo;
    public bool boost;
    [SerializeField] private float startTime;
    private Wallet _wallet;
    private float _boostTime;
    private bool _startedTimer;

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
    }

    private void Start()
    {
        time = startTime;
        _boostTime = 300f;
        weaponSo.weaponIncome = weaponSo.weaponBaseIncome * weaponSo.weaponLevel;
        weaponSo.weaponPrice = (weaponSo.weaponIncome * 2 + weaponSo.weaponLevel * 10) * 1.25f;
    }

    private void Update()
    {
        if (weaponSo.isAuto)
        {
            _startedTimer = true;
        }

        if (!_startedTimer) return;
        if (boost)
        {
            time -= Time.deltaTime * 2;
            _boostTime -= Time.deltaTime;
        }
        else
        {
            time -= Time.deltaTime;
        }

        if (_boostTime <= 0)
        {
            boost = false;
            _boostTime = 300f;
        }

        if (!(time <= 0)) return;
        Earn();
        _startedTimer = false;
        time = startTime;
    }

    private void Earn()
    {
        _wallet.EarnCoins(weaponSo.weaponIncome);
    }

    public void UpgradeWeapon()
    {
        weaponSo.weaponLevel += 1;
        weaponSo.weaponIncome = weaponSo.weaponBaseIncome * weaponSo.weaponLevel;
        weaponSo.weaponPrice = (weaponSo.weaponIncome * 2 + weaponSo.weaponLevel * 10) * 1.25f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (weaponSo.isUnlocked)
        {
            _startedTimer = true;
        }
    }
}