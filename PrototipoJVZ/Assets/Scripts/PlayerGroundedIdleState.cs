using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedIdleState : PlayerBaseState
{
    public Vector2 MoveValue;
    public PlayerGroundedIdleState(PlayerStateContext context, PlayerStateFactory factory)
    : base (context, factory) {
        IsRootState = false;
    }
    public override void EnterState(){
        Ctx.PlayerInputActions.PlayerTest.Dash.performed += Dash;
        Ctx.PlayerInputActions.PlayerTest.Jump.performed += Jump;
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void FixedUpdateState(){
        MoveV2();
    }

    public override void ExitState(){
        Ctx.PlayerInputActions.PlayerTest.Dash.performed -= Dash;
        Ctx.PlayerInputActions.PlayerTest.Jump.performed -= Jump;
    }

    public override void CheckSwitchStates(){
        /*
        If (blah blah) {
            SwitchState(Factory.AirState())
        }
        */
    }

    public override void InitializeSubState(){}

    public void MoveV1(){
        MoveValue = Ctx.PlayerInputActions.PlayerTest.Move.ReadValue<Vector2>();
        Vector3 moveVector = new Vector3 (MoveValue.x, 0, 0) * Ctx.Speed;
        Ctx.Rb.velocity = moveVector;
    }

    public void AccelerationTimeReset(){
        Debug.Log(Time.deltaTime);
    }

    //V2 Would Require the Player object Rigidbody to be Dynamic, so it would not work with Kinematic ones
    public void MoveV2(){
        MoveValue = Ctx.PlayerInputActions.PlayerTest.Move.ReadValue<Vector2>();
        Vector3 moveVector = new Vector3 (MoveValue.x, 0, 0);
        if (moveVector.magnitude != 0){
            Ctx.Rb.AddForce(moveVector * Ctx.Speed, ForceMode.Acceleration);
            Ctx.Rb.drag = Ctx.Drag;
        } else {
            Ctx.Rb.drag = Ctx.Speed / 2;
        }
        if (Ctx.Rb.velocity.x > (Ctx.MaxSpeed) || Ctx.Rb.velocity.x < (- Ctx.MaxSpeed)){
            Ctx.Rb.AddForce(- Ctx.Rb.velocity, ForceMode.Acceleration);
        }
    }

    public void Jump(InputAction.CallbackContext context) {
        if (MoveValue.magnitude != 0){
            SwitchState(Factory.GroundedJump());
        }    
    }

    public void Dash(InputAction.CallbackContext context){
        if (MoveValue.magnitude != 0){
            SwitchState(Factory.GroundedDash(new Vector3(MoveValue.x, MoveValue.y, 0)));
        }    
    }

    public void DashV2(InputAction.CallbackContext context){
        if (MoveValue.magnitude != 0){
            Vector3 dashVector = new Vector3 (MoveValue.x, MoveValue.y, 0);
            Ctx.Rb.AddForce(dashVector * Ctx.DashSpeed, ForceMode.Impulse);
        }
    }
}
