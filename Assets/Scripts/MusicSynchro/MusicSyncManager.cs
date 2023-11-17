using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using System.Linq;
using NaughtyAttributes;
using UnityEngine.InputSystem;
using Durian;

public class MusicSyncManager : MonoBehaviour
{

    [SerializeField] private MMAudioAnalyzer _audioAnalyzer;

    [SerializeField, BoxGroup("Inputs")] private InputActionProperty _levelOfJews;
    public static MusicSyncManager Instance;
    int index = 0;
    private void Awake()
    {
        _levelOfJews.action.started += turnOnOffAnalizer;
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
    }
    public void turnOnOffAnalizer(InputAction.CallbackContext ctx)
    {
        _audioAnalyzer.enabled = false;
        if (_audioAnalyzer.enabled )
            _audioAnalyzer.enabled = false;
        else
            _audioAnalyzer.enabled = true;
    }

    public void AddObjectChildToBeat(GameObject objectToAdd ) 
    {


        if (index > _audioAnalyzer.Beats.Count()-1)
            index = 0;
        if (objectToAdd.TryGetComponent<Entity>(out Entity entityComp))
            if (objectToAdd.TryGetComponent<MMScaleShaker>(out MMScaleShaker scaleShake))
            {
                _audioAnalyzer.Beats[index].OnBeat.AddListener(scaleShake.Play);
                entityComp.beatIndex = index;
                entityComp.isBeating = true;
                index++;
            }
        
    }
    public void RemoveObjectChildToBeat(GameObject objectToRemove)
    {
        if (objectToRemove.TryGetComponent<Entity>(out Entity entityComp))
            if (objectToRemove.TryGetComponent<MMScaleShaker>(out MMScaleShaker scaleShake))
            {
                _audioAnalyzer.Beats[entityComp.beatIndex].OnBeat.RemoveListener(scaleShake.Play);

            }
    }
}
