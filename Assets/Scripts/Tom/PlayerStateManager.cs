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
        //print("���˖�"+reflectWallNormal.Count);
        for(int i=0;i<reflectWallContact.Count;i++)
        {
            print("��"+i +" :"+reflectWallContact[i]);
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
        // �ڐG�����I�u�W�F�N�g���擾
        GameObject collidedObject = collision.gameObject;

        // ���Ƀ��X�g�Ɋ܂܂�Ă���ꍇ�͏����𒆒f
        if (reflectWallObj.Contains(collidedObject))
        {
            return;
        }

        // ���X�g�ɃI�u�W�F�N�g��ǉ�
        reflectWallObj.Add(collidedObject);

        // ContactPoint�̍ŏ��̗v�f�݂̂�����
        ContactPoint contact = collision.contacts[0];

        // �ڐG�_�̏������X�g�ɒǉ�
        reflectWallContact.Add(contact);
        //reflectWallNormal.Add(contact.normal);
    }

    /// <summary>
    /// 2�ʐڂ��Ă����Ԃ���1�ʂɂȂ����Ƃ��ɔ��˂���ƕǂ̖@����0�ɂȂ���������B
    /// ����ɂ���𓮂����Ă���Ɣ��˃��[�h�ŋ��������������Ȃ邽�ߔ��˃��[�h�ł�off
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
                print("��v");
                reflectWallObj.RemoveAt(i);
                reflectWallContact.RemoveAt(i);
            }
        }
    }

}
