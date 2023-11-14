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

        public void Move(Vector2 read)
        {
            _rb.velocity = Vector2.zero;
            _read = read;
        }
    }
}

