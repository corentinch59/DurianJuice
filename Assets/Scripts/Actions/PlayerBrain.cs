using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Durian.Actions
{
    public class PlayerBrain : MonoBehaviour
    {
        [SerializeField, BoxGroup("Dependencies")] private PlayerMovement _movement;
        //[SerializeField, BoxGroup("Dependencies")] attack

        [SerializeField, BoxGroup("Input")] private InputActionProperty _moveInput;
        [SerializeField, BoxGroup("Input")] private InputActionProperty _attackInput;

        private void Awake()
        {
            _moveInput.action.Enable();
            _attackInput.action.Enable();
        }

        private void Start()
        {
            _moveInput.action.started += Movement;
            _moveInput.action.performed += Movement;
            _moveInput.action.canceled += StopMovement;
            _attackInput.action.started += Shoot;
        }

        private void OnDestroy()
        {
            _moveInput.action.started -= Movement;
            _moveInput.action.performed -= Movement;
            _moveInput.action.canceled -= StopMovement;
            _attackInput.action.started -= Shoot;
        }

        private void Movement(InputAction.CallbackContext ctx)
        {
            _movement.Move(ctx.ReadValue<Vector2>());
        }

        private void StopMovement(InputAction.CallbackContext ctx)
        {
            _movement.Move(Vector2.zero);
        }

        private void Shoot(InputAction.CallbackContext ctx)
        {
            Debug.Log("Pew !");
        }

    }
}

