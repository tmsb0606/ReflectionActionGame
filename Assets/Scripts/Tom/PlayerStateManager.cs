using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public partial class PlayerStateManager : MonoBehaviour
{
    private PlayerStateBase moveState = new PlayerMoveState();
    private PlayerStateBase reflectionState = new PlayerReflectionState();
    public List<GameObject> reflectWallObj = new List<GameObject>();
    public List<ContactPoint> reflectWallContact = new List<ContactPoint>();
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
        //print("反射面"+reflectWallNormal.Count);
        for(int i=0;i<reflectWallContact.Count;i++)
        {
            print("壁"+i +" :"+reflectWallContact[i]);
        }
    }

    private void ChangeState(PlayerStateBase nextState)
    {
        currentState.OnExit(this, nextState);
        nextState.OnEnter(this, currentState);
        currentState = nextState;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 接触したオブジェクトを取得
        GameObject collidedObject = collision.gameObject;

        // 既にリストに含まれている場合は処理を中断
        if (reflectWallObj.Contains(collidedObject))
        {
            return;
        }

        // リストにオブジェクトを追加
        reflectWallObj.Add(collidedObject);

        // ContactPointの最初の要素のみを処理
        ContactPoint contact = collision.contacts[0];

        // 接触点の情報をリストに追加
        reflectWallContact.Add(contact);
        //reflectWallNormal.Add(contact.normal);
    }

    /// <summary>
    /// 2面接している状態から1面になったときに発射すると壁の法線が0になる問題を解決。
    /// ※常にこれを動かしていると反射モードで挙動がおかしくなるため反射モードではoff
    /// </summary>
    /// <param name="collision"></param>
    /*private void OnCollisionStay(Collision collision)
    {
        print("stay");
        if(currentState  == reflectionState) {
            return;
        }
        *//*        print(reflectWall.Contains(collision));
                if(reflectWall.Contains(collision))
                {
                    return;
                }*//*


        reflectWallObj.Add(collision.gameObject);
        ContactPoint[] contact = new ContactPoint[1];
        collision.GetContacts(contact);

        if (reflectWallContact.Contains(contact[0]))
        {
            return;
        }

        reflectWallContact.Add(contact[0]);
        reflectWallNormal.Add(contact[0].normal);
    }*/
    private void OnCollisionExit(Collision collision)
    {

        for(int i=0;i<reflectWallObj.Count;i++)
        {
            if (reflectWallObj[i] == collision.gameObject)
            {
                print("一致");
                reflectWallObj.RemoveAt(i);
                reflectWallContact.RemoveAt(i);
            }
        }
    }

}
