using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedDashState : PlayerBaseState
{
    private Vector3 _direction;
    private float _timer;
    private bool _active = true;
    //private delegate IEnumerator 
    public PlayerGroundedDashState(PlayerStateContext context, PlayerStateFactory factory, Vector3 direction)
    : base (context, factory) {
        _direction = direction;
        _timer = 1.0f;
    }
    public override void EnterState(){
        Vector3 dashVector = new Vector3 (_direction.x, _direction.y, 0);
        Ctx.Rb.AddForce(dashVector * Ctx.DashSpeed, ForceMode.Impulse);
        Ctx.Render.material.SetColor("_Color", Color.red);
        Ctx.StartCoroutine(StartCountdown());
    }

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
        if (!_active){
            Ctx.Render.material.SetColor("_Color", Ctx.OriginalColor);
            SwitchState(Factory.GroundedIdle());
        }
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

    private IEnumerator StartCountdown(){
        yield return new WaitForSeconds(_timer);
        _active = false;
    }
}
