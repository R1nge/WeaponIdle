using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float startTime;
    private float _time;
    private bool _boost;
    private float _boostTime;
    public static Action TimeEndEvent;

    private void Start()
    {
        _time = startTime;
        _boostTime = 300f;
    }

    private void Update()
    {
        if (_boost)
        {
            _time -= Time.deltaTime * 2;
            _boostTime -= Time.deltaTime;
        }
        else
        {
            _time -= Time.deltaTime;
        }

        if (!(_time <= 0)) return;
        TimeEndEvent?.Invoke();
        print("Timer");
        _time = startTime;
    }

    public void ApplyBoost()
    {
        if (!_boost)
        {
            _boost = true;
        }

        if (_boostTime <= 0)
        {
            _boost = false;
        }
    }
}