using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using System.Linq;
using NaughtyAttributes;
using UnityEngine.InputSystem;

public class MusicSyncManager : MonoBehaviour
{

    [SerializeField] private MMAudioAnalyzer _audioAnalyzer;

    [SerializeField, BoxGroup("Inputs")] private InputActionProperty _levelOfJews;

    private void Awake()
    {
        _levelOfJews.action.started += turnOnOffAnalizer;
    }
    public void turnOnOffAnalizer(InputAction.CallbackContext ctx)
    {
        _audioAnalyzer.enabled = false;
        if (_audioAnalyzer.enabled )
            _audioAnalyzer.enabled = false;
        else
            _audioAnalyzer.enabled = true;
    }

    public void AddObjectChildToBeat(Transform objectToAdd ) 
    {
        int index = 0;
        foreach (Transform child in objectToAdd.transform)
        {
            
            if (index > _audioAnalyzer.Beats.Count()-1)
                index = 0;

            if (child.TryGetComponent<MMScaleShaker>(out MMScaleShaker scaleShake))
            {
                _audioAnalyzer.Beats[index].OnBeat.AddListener(scaleShake.Play);
                index++;
            }
        }
    }
}
