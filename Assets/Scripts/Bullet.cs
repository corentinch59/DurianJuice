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
        [SerializeField, BoxGroup("Events")] private UnityEvent _onBulletSpawned;

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

        public event UnityAction OnBulletSpawned
        {
            add => _onBulletSpawned.AddListener(value);
            remove => _onBulletSpawned.RemoveListener(value);
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > 2)
            {
                Destroy(gameObject,5);
            }
        }

        public void InitBullet(Vector2 direction)
        {
            _rb.velocity = direction * _bulletSpeed;
            _onBulletSpawned?.Invoke();
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
                Destroy(gameObject,5f);
            }
        }
    }
}

