
public class PlayerStateFactory 
{
    private PlayerStateContext _context;
    public PlayerStateFactory(PlayerStateContext currentContext){
        _context = currentContext;
    }

    public PlayerBaseState Grounded(){
        return new PlayerGroundedState(_context, this);
    }
    
    public PlayerBaseState GroundedIdle(){
        return new PlayerGroundedIdleState(_context, this);
    }

    public PlayerBaseState InAir(){
        return new PlayerInAirState(_context, this);
    }

    public PlayerBaseState InAirIdle(){
        return new PlayerInAirIdleState(_context, this);
    }
    
}
