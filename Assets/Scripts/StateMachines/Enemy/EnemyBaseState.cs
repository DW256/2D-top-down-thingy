using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;
    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public override void Tick(float deltaTime)
    {
        FlipSprite();
    }

    void FlipSprite()
    {
        //Sprite Flipping
        float playerX = stateMachine.Player.transform.position.x;
        float enemyX = stateMachine.transform.position.x;
        if (playerX != enemyX)
        {
            bool flip = playerX < enemyX; //Player on left side
            stateMachine.AvatarSprite.flipX = flip;
        }
    }

    //protected void Move(Vector2 motion, float deltaTime)
    //{
    //    stateMachine.Rigidbody.velocity = motion + stateMachine.ForceReceiver.Movement;
    //}

    //protected void Move(float deltaTime)
    //{
    //    Move(Vector2.zero, deltaTime);
    //}

}
