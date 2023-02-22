using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateContext context, PlayerStateFactory factory)
    : base (context, factory) {
        IsRootState = true;
        InitializeSubState();
    }
    public override void EnterState(){}

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void FixedUpdateState(){}

    public override void ExitState(){}

    public override void CheckSwitchStates(){
        /*
        If (blah blah) {
            SwitchState(Factory.AirState())
        }
        */
    }

    public override void InitializeSubState(){
        /*
        If (blah blah) {
            SetSubState(Factory.Idle())
        } else if(blah blah b){
            SetSubState(Factory.Dash())
        }
        */
        SetSubState(Factory.GroundedIdle());
    }
}
