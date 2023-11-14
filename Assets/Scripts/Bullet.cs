using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

namespace Durian
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField, BoxGroup("Dependencies")] private Rigidbody2D _rb;

        [SerializeField, BoxGroup("Setup")] private float _bulletSpeed;
        [SerializeField, BoxGroup("Setup")] private float _damage;

        private float _elapsedTime;
        private GameObject _owner;

        public GameObject Owner
        {
            get => _owner;
            set => _owner = value;
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
            if (_owner == other.gameObject) return;

            IHitable hitable;
            if (other.gameObject.TryGetComponent<IHitable>(out hitable))
            {
                hitable.Hit(1);
                Destroy(gameObject);
            }
        }
    }
}

