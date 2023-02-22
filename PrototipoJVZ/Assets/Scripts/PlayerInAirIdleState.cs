using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirIdleState : PlayerBaseState
{
    public PlayerInAirIdleState(PlayerStateContext context, PlayerStateFactory factory)
    : base (context, factory) {
        
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
            SetSubState(Factory.InAirIdle())
        } else if(blah blah b){
            SetSubState(Factory.Dash())
        }
        */
    }
}
