public interface IEntity
{
    string Name { get; set; }
    void TakeDamage(int damage);
    void Heal(int amount);
    void Attack(IEntity target);
}