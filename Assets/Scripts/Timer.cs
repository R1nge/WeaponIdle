using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float startTime;
    private float _time;
    public Action TimeEndEvent;

    private void Start()
    {
        _time = startTime;
    }

    private void Update()
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
        {
            TimeEndEvent?.Invoke();
            _time = startTime;
        }
    }
}