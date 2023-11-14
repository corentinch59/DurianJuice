using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Durian.Actions
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, BoxGroup("Dependencies")] private Rigidbody2D _rb;
        [SerializeField, BoxGroup("Dependencies")] private Transform _playerTransform;

        [SerializeField, BoxGroup("Setup")] private float _speed;
        [SerializeField, BoxGroup("Setup")] private float _maxSpeed;

        private Vector2 _read;
        private Vector3 leftEdge;
        private Vector3 rightEdge;

        private void Start()
        {
            leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        }

        private void FixedUpdate()
        {
            if(_read == Vector2.zero)
                _rb.velocity = Vector2.zero;

            if (_read == Vector2.right && _playerTransform.position.x >= rightEdge.x)
            {
                _rb.velocity = Vector2.zero;
                return;
            }

            if (_read == Vector2.left & _playerTransform.position.x <= leftEdge.x)
            {
                _rb.velocity = Vector2.zero;
                return;
            }

            _rb.AddForce(_read * _speed * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        public void Move(Vector2 read)
        {
            _rb.velocity = Vector2.zero;
            _read = read;
        }
    }
}

