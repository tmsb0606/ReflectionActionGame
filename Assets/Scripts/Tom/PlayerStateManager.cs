using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerStateManager : MonoBehaviour
{
    private PlayerStateBase moveState = new PlayerMoveState();
    private PlayerStateBase reflectionState = new PlayerReflectionState();
    public List<Collision> reflectWall = new List<Collision>();
    public float reflectSpeed = 10.0f;

    public Rigidbody rb;
    public PlayerStateBase currentState { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        currentState = moveState;
        currentState.OnEnter(this,null);
        rb = GetComponent<Rigidbody>();
        //ChangeState(reflectionState);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdata(this);
        print("”½ŽË–Ê"+reflectWall.Count);
    }

    private void ChangeState(PlayerStateBase nextState)
    {
        currentState.OnExit(this, nextState);
        nextState.OnEnter(this, currentState);
        currentState = nextState;
    }

    private void OnCollisionEnter(Collision collision)
    {
        reflectWall.Add(collision); ;
    }
    private void OnCollisionExit(Collision collision)
    {
        reflectWall.Remove(collision);
    }
}
