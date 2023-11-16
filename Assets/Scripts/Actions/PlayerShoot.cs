using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Durian.Actions
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField, BoxGroup("Prefab")] private Bullet _bullet;

        [SerializeField, BoxGroup("Setup")] private float _fireRate;

        [SerializeField, BoxGroup("Events")] private UnityEvent _onShoot;

        public event UnityAction OnShoot
        {
            add => _onShoot.AddListener(value);
            remove => _onShoot.RemoveListener(value);
        }

        private bool CanShoot => _elapsedTime > _fireRate;
        private float _elapsedTime;

        private void Update()
        {
            if (_elapsedTime < _fireRate)
            {
                _elapsedTime += Time.deltaTime;
            }
        }

        public void ShootBullet()
        {
            if (!CanShoot) return;

            _elapsedTime = 0.0f;
            Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.InitBullet(new Vector2(0.0f, 1.0f));
            bullet.Owner = gameObject;
            _onShoot?.Invoke();
        }
    }
}
