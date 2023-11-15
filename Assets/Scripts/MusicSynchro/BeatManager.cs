using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _source;
    [SerializeField] private Intervals[] _intervals;
    private void Update()
    {
        foreach (var interval in _intervals)
        {
            float smapledTime = (_source.timeSamples / (_source.clip.frequency * interval.GetIntervalLenght(_bpm)));
            interval.CheckForNewInterval(smapledTime);
        }
    }
}

[System.Serializable]
public class Intervals
{

    [SerializeField] private float _steps;
    [SerializeField] private UnityEvent _trigger;
    private int _lastInterval;
    public float GetIntervalLenght(float bpm)
    { return 60/bpm * _steps; }

    public void CheckForNewInterval(float interval)
    {


        if(Mathf.FloorToInt(interval) != _lastInterval)
        {
            _lastInterval=Mathf.FloorToInt(interval);
            _trigger.Invoke();
        }
    }
}
