using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameFeelManager : MonoBehaviour
{
    private static GameFeelManager _instance;
    public static GameFeelManager Instance => _instance;

    [SerializeField] private InputActionProperty _onTouchGamefeel;
    
    private bool _onTouchEvent = false;
    public bool OnTouchEvent => _onTouchEvent;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _onTouchGamefeel.action.Enable();
    }

    private void Start()
    {
        _onTouchGamefeel.action.started += EnableDieEffect;
    }

    private void EnableDieEffect(InputAction.CallbackContext ctx)
    {
        _onTouchEvent = !_onTouchEvent;
        Debug.Log(_onTouchEvent);
    }
}
