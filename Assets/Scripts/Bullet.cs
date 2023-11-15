using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Durian
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField, BoxGroup("Dependencies")] private Rigidbody2D _rb;

        [SerializeField, BoxGroup("Setup")] private float _bulletSpeed;
        [SerializeField, BoxGroup("Setup")] private float _damage;

        [SerializeField, BoxGroup("Events")] private UnityEvent _onBulletTouched;

        private float _elapsedTime;
        private GameObject _owner;

        public GameObject Owner
        {
            get => _owner;
            set => _owner = value;
        }

        public event UnityAction OnBulletTouched
        {
            add => _onBulletTouched.AddListener(value);
            remove => _onBulletTouched.RemoveListener(value);
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > 2)
            {
                Destroy(gameObject);
            }
        }

        public void InitBullet(Vector2 direction)
        {
            _rb.velocity = direction * _bulletSpeed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Owner is : " + _owner.tag + " other is : " + other.gameObject.tag);
            if (_owner.tag == other.gameObject.tag) return;

            IHitable hitable;
            if (other.gameObject.TryGetComponent<IHitable>(out hitable))
            {
                hitable.Hit(1);
                _onBulletTouched?.Invoke();
            }
        }
    }
}

