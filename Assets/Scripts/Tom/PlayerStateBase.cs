
public class PlayerStateBase
{
    public virtual  void OnEnter(PlayerStateManager owner, PlayerStateBase prevState) { }
    public virtual  void OnUpdata(PlayerStateManager owner) { }
    public virtual  void OnExit(PlayerStateManager owner, PlayerStateBase prevState) { }
    public  int boundCount;
}
