using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Durian.Actions
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, BoxGroup("Dependencies")] private Rigidbody2D _rb;
        [SerializeField, BoxGroup("Dependencies")] private Transform _playerTransform;

        [SerializeField, BoxGroup("Setup")] private float _speed;
        [SerializeField, BoxGroup("Setup")] private float _maxSpeed;
        [SerializeField, BoxGroup("Setup")] private float _edgeOffset;

        [SerializeField, BoxGroup("Events")] private UnityEvent _onMovement;

        public event UnityAction OnMovement
        {
            add => _onMovement.AddListener(value);
            remove => _onMovement.RemoveListener(value);
        }

        private Vector2 _read;
        private Vector3 _leftEdge;
        private Vector3 _rightEdge;

        private void Start()
        {
            _leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            _rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        }

        private void FixedUpdate()
        {
            if(_read == Vector2.zero)
                _rb.velocity = Vector2.zero;

            if (_read == Vector2.right && _playerTransform.position.x >= _rightEdge.x -_edgeOffset)
            {
                _rb.velocity = Vector2.zero;
                return;
            }

            if (_read == Vector2.left & _playerTransform.position.x <= _leftEdge.x + _edgeOffset)
            {
                _rb.velocity = Vector2.zero;
                return;
            }

            _rb.AddForce(_read * _speed * Time.fixedDeltaTime, ForceMode2D.Force);
            _onMovement?.Invoke();
        }

        public void Move(Vector2 read)
        {
            _rb.velocity = Vector2.zero;
            _read = read;
        }
    }
}

