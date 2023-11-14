
namespace Durian
{
    public interface IDamageable
    {
        public void TakeDamage(float amount);
        public void Recover(float amount);
        public void Die();
    }
}

