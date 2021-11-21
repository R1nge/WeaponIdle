using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float startTime;
    public float time;
    private bool _boost;
    private float _boostTime;
    public static Action TimeEndEvent;

    private void Start()
    {
        time = startTime;
        _boostTime = 300f;
    }

    private void Update()
    {
        if (_boost)
        {
            time -= Time.deltaTime * 2;
            _boostTime -= Time.deltaTime;
        }
        else
        {
            time -= Time.deltaTime;
        }

        if (!(time <= 0)) return;
        TimeEndEvent?.Invoke();
        print("Timer");
        time = startTime;
    }

    public void ApplyBoost()
    {
        if (!_boost)
        {
            _boost = true;
            //Show AD
        }

        if (_boostTime <= 0)
        {
            _boost = false;
        }
    }
}