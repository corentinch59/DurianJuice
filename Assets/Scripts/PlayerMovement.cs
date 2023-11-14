using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Durian
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, BoxGroup("Dependencies")] private Rigidbody2D _rb;

        [SerializeField, BoxGroup("Setup")] private float _speed;
        [SerializeField, BoxGroup("Setup")] private float _maxSpeed;

        private Vector2 _read;

        private void FixedUpdate()
        {
            if(_read == Vector2.zero)
                _rb.velocity = Vector2.zero;

            _rb.AddForce(_read * _speed * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        public void Move(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                _rb.velocity = Vector2.zero;
            }

            if (ctx.performed)
            {
                _read = ctx.ReadValue<Vector2>();
                Debug.Log(_read);
            }

            if (ctx.canceled)
            {
                _read = Vector2.zero;
                _rb.velocity = Vector2.zero;
            }

        }
    }
}

