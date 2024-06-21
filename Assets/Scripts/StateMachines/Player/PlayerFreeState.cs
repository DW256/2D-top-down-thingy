using UnityEngine;

public class PlayerFreeState : PlayerBaseState
{
    private readonly int RunHash = Animator.StringToHash("PlayerRun");
    public PlayerFreeState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.InputReader.ShootEvent += OnShoot;
        stateMachine.Animator.Play(RunHash);
    }

    public override void Exit()
    {
        stateMachine.InputReader.ShootEvent -= OnShoot;
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
        }

        float mouseX = stateMachine.InputReader.MousePosition.x;
        float playerX = stateMachine.transform.position.x;
        bool facingRight = playerX < mouseX;
        bool inputRight = stateMachine.InputReader.MovementValue.x > 0;
        stateMachine.Animator.SetFloat("RunDirection", (facingRight == inputRight) ? 1f : -1f);

        Move(CalculateMovement(), deltaTime);
        base.Tick(deltaTime);
    }

    Vector2 CalculateMovement()
    {
        Vector2 movement = stateMachine.InputReader.MovementValue * stateMachine.MovementSpeed;
        return movement;
    }
}