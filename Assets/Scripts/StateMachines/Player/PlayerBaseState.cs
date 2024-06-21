using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public override void Tick(float deltaTime)
    {
        HandleAim();
        FlipSprites();
    }
    protected void Move(Vector2 motion, float deltaTime)
    {
        stateMachine.Rigidbody.velocity = motion + stateMachine.ForceReceiver.Movement;
        //stateMachine.Rigidbody.MovePosition(new Vector2(stateMachine.transform.position.x, stateMachine.transform.position.y) + motion * deltaTime);
    }

    protected void Move(float deltaTime)
    {
        Move(Vector2.zero, deltaTime);
    }

    void HandleAim()
    {
        Vector3 aimDirection = (stateMachine.InputReader.MousePosition - stateMachine.Aim.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        stateMachine.Aim.eulerAngles = new Vector3(0f, 0f, angle);
    }

    void FlipSprites()
    {
        //Sprite Flipping
        float mouseX = stateMachine.InputReader.MousePosition.x;
        float playerX = stateMachine.transform.position.x;
        if (mouseX != playerX)
        {
            bool flip = mouseX < playerX; //Mouse pointer on left side
            stateMachine.AvatarSprite.flipX = flip;
            stateMachine.Gun.Sprite.flipY = flip;
        }
    }

    protected void OnShoot()
    {
        if (!stateMachine.Gun.canShoot) return;

        float damageModifier = stateMachine.DamageModifier;
        float bulletSpeedModifier = stateMachine.BulletSpeedModifier;
        float knockbackModifier = stateMachine.KnockbackModifier;
        float shootIntervalModifier = stateMachine.ShootIntervalModifier;
        Collider2D shooter = stateMachine.Collider;

        //Quaternion rotation = stateMachine.Aim.transform.rotation;
        //stateMachine.Gun.Shoot(rotation, damageModifier, bulletSpeedModifier, knockbackModifier, shootIntervalModifier);
        stateMachine.Gun.Shoot(damageModifier, bulletSpeedModifier, knockbackModifier, shootIntervalModifier, shooter);
    }

}
