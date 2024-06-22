using UnityEngine;

[CreateAssetMenu(menuName = "Power Ups/Health Buff")]
public class HealthBuff : PowerUpEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().addHealth(amount);
    }
}
