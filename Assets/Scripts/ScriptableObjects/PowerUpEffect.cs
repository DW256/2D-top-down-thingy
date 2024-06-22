using UnityEngine;

public abstract class PowerUpEffect : ScriptableObject
{
    public Sprite Sprite;
    public abstract void Apply(GameObject target);
}
