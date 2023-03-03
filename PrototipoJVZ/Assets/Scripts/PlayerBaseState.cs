public abstract class PlayerBaseState
{
    private bool _isRootState = false;
    private PlayerStateContext _ctx;
    private PlayerStateFactory _factory;
    private PlayerBaseState _currentSuperState;
    private PlayerBaseState _currentSubState;
    
    protected bool IsRootState{ set {_isRootState = value;}}
    protected PlayerStateContext Ctx { get { return _ctx; }}
    protected PlayerStateFactory Factory { get { return _factory;}}

    public PlayerBaseState(PlayerStateContext context, PlayerStateFactory factory){
        _ctx = context;
        _factory = factory;
    }
    
    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void FixedUpdateState();

    public abstract void ExitState();

    public abstract void CheckSwitchStates();

    public abstract void InitializeSubState();

    public void UpdateStates(){
        UpdateState();
        if (_currentSubState != null) {
            _currentSubState.UpdateStates();
        }
    }

    public void FixedUpdateStates(){
        FixedUpdateState();
        if (_currentSubState != null) {
            _currentSubState.FixedUpdateStates();
        }
    }

    public void ExitStates(){
        ExitState();
        if (_currentSubState != null) {
            _currentSubState.ExitStates();
        }
    }

    public void EnterStates(){
        EnterState();
        if (_currentSubState != null) {
            _currentSubState.EnterStates();
        }
    }

    protected void SwitchState(PlayerBaseState newState){
        ExitStates();
        newState.EnterStates();

        if (_isRootState) {
            _ctx.CurrentState = newState;
        } else if (_currentSuperState != null){
            _currentSuperState.SetSubState(newState);
        }
    }

    protected void SetSuperState(PlayerBaseState newSuperState){
        _currentSuperState = newSuperState;
    }

    protected void SetSubState(PlayerBaseState newSubState){
        _currentSubState = newSubState;
        newSubState.SetSuperState(this);
        newSubState.EnterStates();
    }
    }
