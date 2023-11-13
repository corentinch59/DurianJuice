using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Durian
{
    public class Health : MonoBehaviour, IDamageable
    {
        private Alterable<float> _maxHealth;

        public float CurrentHealth { get; private set; }

        public bool IsDead => CurrentHealth > 0;
        public Alterable<float> MaxHealth { get => _maxHealth ??= new Alterable<float>(CurrentHealth); }

        public event Action<float> OnDamage;
        public event Action<float> OnRegen;
        public event Action OnDie;

        public void TakeDamage(float amount)
        {
            Assert.IsTrue(amount >= 0);
            if (IsDead) return;

            CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
            OnDamage?.Invoke(amount);
        }

        public void Recover(float amount)
        {
            Assert.IsTrue(amount >= 0);
            if (IsDead) return;

            CurrentHealth = Mathf.Min(_maxHealth.CalculateValue(), CurrentHealth + amount);
            OnRegen?.Invoke(amount);
        }

        public void Die()
        {
            if (!IsDead) return;
            OnDie?.Invoke();
        }
    }
}

