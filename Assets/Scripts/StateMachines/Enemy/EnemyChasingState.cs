using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.Agent.destination = stateMachine.Player.transform.position;
        Move(CalculateMovement(), deltaTime);
        base.Tick(deltaTime);
    }

    Vector2 CalculateMovement()
    {
        Vector2 movement = stateMachine.Agent.velocity * stateMachine.speed;
        return movement;
    }
}
