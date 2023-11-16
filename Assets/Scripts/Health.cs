using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace Durian
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth;

        public int CurrentHealth { get; private set; }

        public bool IsDead => CurrentHealth <= 0;

        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onDie;
        [SerializeField] private UnityEvent<int> _onHealth;

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

        public event UnityAction<int> OnHealth
        {
            add => _onHealth.AddListener(value);
            remove => _onHealth.RemoveListener(value);
        }


        private void Start()
        {
            CurrentHealth = _maxHealth;
        }

        public void TakeDamage(int amount)
        {
            Assert.IsTrue(amount >= 0);
            if (IsDead) return;

            CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
            _onDamage?.Invoke();
            _onHealth?.Invoke(CurrentHealth);
            Die();
        }

        public void Die()
        {
            if (!IsDead) return;
            _onDie?.Invoke();

            GetComponent<Animator>().SetBool("IsDead", true);
        }
    }
}

