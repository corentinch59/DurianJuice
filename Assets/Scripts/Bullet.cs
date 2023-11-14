using System.Collections;
using System.Collections.Generic;
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
    }
}

