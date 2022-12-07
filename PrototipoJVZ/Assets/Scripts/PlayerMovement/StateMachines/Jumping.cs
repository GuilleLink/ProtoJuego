using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : BaseState
{
    private MovementSM _sm;
    private bool _grounded;

    private int _groundLayer = 1 << 6;

    public Jumping(MovementSM stateMachine) : base("Jumping", stateMachine) {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        Vector2 vel = _sm.playerRb.velocity;
        vel.y += _sm.jumpForce;
        _sm.playerRb.velocity = vel;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_grounded)
            stateMachine.ChangeState(_sm.idleState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        //add check for if player is touching ground
        // && _sm.rigidbody.IsTouchingLayers(_groundLayer); (implement equivalent of this)
        _grounded = _sm.playerRb.velocity.y < Mathf.Epsilon;
    }
}