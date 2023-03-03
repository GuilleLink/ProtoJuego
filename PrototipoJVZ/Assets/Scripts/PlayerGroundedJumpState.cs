using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedJumpState : PlayerBaseState
{
    public PlayerGroundedJumpState(PlayerStateContext context, PlayerStateFactory factory)
    : base (context, factory) {
        IsRootState = false;
    }
    public override void EnterState(){
        Vector3 dashVector = new Vector3 (0, 1, 0);
        Ctx.Rb.AddForce(dashVector * Ctx.DashSpeed, ForceMode.Impulse);
        Ctx.Render.material.SetColor("_Color", Color.blue);
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void FixedUpdateState(){
        
    }

    public override void ExitState(){}

    public override void CheckSwitchStates(){
        /*
        If (blah blah) {
            SwitchState(Factory.AirState())
        }
        */
    }

    public override void InitializeSubState(){}


}
