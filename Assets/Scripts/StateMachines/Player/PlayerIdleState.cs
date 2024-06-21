using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    private readonly int IdleHash = Animator.StringToHash("PlayerIdle");
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.InputReader.ShootEvent += OnShoot;
        stateMachine.Animator.Play(IdleHash);
    }

    public override void Exit()
    {
        stateMachine.InputReader.ShootEvent -= OnShoot;
    }

    public override void Tick(float deltaTime) { 
        base.Tick(deltaTime);
        if (stateMachine.InputReader.MovementValue != Vector2.zero) {
            stateMachine.SwitchState(new PlayerFreeState(stateMachine));
        }
        Move(deltaTime);
    }
}