using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace Durian
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _maxHealth;

        public float CurrentHealth { get; private set; }

        public bool IsDead => CurrentHealth <= 0;

        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onDie;

        public event UnityAction OnDamage
        {
            add => _onDamage.AddListener(value);
            remove => _onDamage.RemoveListener(value);
        }

        public event UnityAction OnDie
        {
            add => _onDie.AddListener(value);
            remove => _onDie.RemoveListener(value);
        }


        private void Start()
        {
            CurrentHealth = _maxHealth;
        }

        public void TakeDamage(float amount)
        {
            Assert.IsTrue(amount >= 0);
            if (IsDead) return;

            CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
            _onDamage?.Invoke();
            Die();
        }

        public void Die()
        {
            if (!IsDead) return;
            Destroy(gameObject);
            _onDie?.Invoke();
        }
    }
}

