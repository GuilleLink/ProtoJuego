using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//This class will contain the different variables and properties that will provide context to the actual state machine
//such gravity and others

//cameCase vs PascalCase

//PascalCase - ClassNames, Methods, Functions, PublicMemberVariables, ProtectedMemberVariables
//camelCase - parameters, arguments, methodVariables, functionVariables, _privateMemberVariables, m_privateMemberVariables
//Static member variables are always written at the top of the class, 
//Interfaces should start with a capital I
//Enums should use PascalCase
public class PlayerStateContext : MonoBehaviour
{
    //
    
    private PlayerBaseState _currentState;
    private PlayerStateFactory _states;
    [SerializeField]
    private float _speed = 30f;
    [SerializeField]
    private float _maxSpeed = 5f;
    [SerializeField]
    private float _drag = 1.0f;
    [SerializeField]
    private float _dashSpeed = 20f;
    private float _velocityTimer = 0f;
    private float _velocityDirection = 1f;
    private float _velocity = 0f;
    public PlayerInputs PlayerInputActions;
    public Rigidbody Rb;
    public PlayerBaseState CurrentState {get {return _currentState;} set {_currentState = value;}}
    public float Speed {get {return _speed;} set {_speed = value;}}
    public float MaxSpeed {get {return _maxSpeed;} set {_maxSpeed = value;}}
    public float Drag {get {return _drag;} set {_drag = value;}}
    public float DashSpeed {get {return _dashSpeed;} set {_dashSpeed = value;}}
    
    void Awake() {
        //setup state
        PlayerInputActions = new PlayerInputs();
        Rb = this.GetComponent<Rigidbody>();
        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();
        //PlayerInputActions.PlayerTest.Move.performed += move;
        PlayerInputActions.PlayerTest.Enable();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateStates();
    }

    private void FixedUpdate() {
        _currentState.FixedUpdateStates();
    }

}
