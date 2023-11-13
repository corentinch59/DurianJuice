using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Durian
{
    public class PlayerBrain : MonoBehaviour
    {
        [SerializeField, BoxGroup("Dependencies")] private IPlayerMovement _movement;
        //[SerializeField, BoxGroup("Dependencies")] attack

        [SerializeField, BoxGroup("Input")] private InputActionProperty _moveInput;
        [SerializeField, BoxGroup("Input")] private InputActionProperty _attackInput;

        private void Start()
        {
            _moveInput.action.started += _movement.Move;
        }

        private void OnDestroy()
        {
            _moveInput.action.started -= _movement.Move;
        }
    }
}

