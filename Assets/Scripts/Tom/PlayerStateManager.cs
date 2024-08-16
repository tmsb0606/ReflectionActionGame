using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerStateManager : MonoBehaviour
{
    private PlayerStateBase moveState = new PlayerMoveState();
    private PlayerStateBase reflectionState = new PlayerReflectionState();
    public Collision reflectWall;
    public PlayerStateBase currentState { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        currentState = moveState;
        currentState.OnEnter(this,null);
        //ChangeState(reflectionState);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdata(this);
    }

    private void ChangeState(PlayerStateBase nextState)
    {
        currentState.OnExit(this, nextState);
        nextState.OnEnter(this, currentState);
        currentState = nextState;
    }

    private void OnCollisionEnter(Collision collision)
    {
        reflectWall = collision;
    }
}
