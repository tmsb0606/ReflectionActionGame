using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Audio;

public partial class PlayerStateManager
{
    public class PlayerReflectionState : PlayerStateBase
    {
        Vector3 vec = new Vector3(1, 0.3f, 0);
        public override void OnEnter(PlayerStateManager owner, PlayerStateBase prevState)
        {
            boundCount = prevState.boundCount;
            print(boundCount);


            owner.GetComponent<Rigidbody>().useGravity = false;
            owner.GetComponent<TrailRenderer>().enabled = true;
            Vector3 mousePos = Input.mousePosition;
            Vector3 screenMousePos = new Vector3(mousePos.x, mousePos.y, 10);
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(screenMousePos);

            vec = (worldMousePos - owner.transform.position).normalized;

            print("vec"+vec);

/*            for (int i = 0; i < owner.reflectWallNormal.Count - 1; i++)
            {


                float angle = Vector3.Angle(vec, owner.reflectWallNormal[0]);
                float angle2 = Vector3.Angle(vec, owner.reflectWallNormal[1]);
                print("angle1:" + angle);
                print("angle2:" + angle2);

                if (angle < angle2)
                {
                    Vector3 temp = owner.reflectWallNormal[i];
                    owner.reflectWallNormal[i] = owner.reflectWallNormal[i + 1];
                    owner.reflectWallNormal[i + 1] = temp;


                }
            }*/

            for (int i = 0; i < owner.reflectWallNormal.Count; i++)
            {

                // vec = Vector3.Reflect(owner.GetComponent<Rigidbody>().velocity.normalized, contact[0].normal);

                print("playervec:" + vec);
                //print("wallvec :" + contact[0].normal);
                float angle = Vector3.Angle(vec, owner.reflectWallNormal[i]);
                print("angle" + angle);
                if (angle >= 90)
                {
                    //owner.reflectWall.Clear();
                    owner.reflectWallNormal.Remove(owner.reflectWallNormal[i]);
                }
                else
                {

                    vec = Vector3.Reflect(vec, owner.reflectWallNormal[i]);
                    boundCount--;
                }

                //owner.reflectWall = null;
            }
           // owner.reflectWall.Clear();

            //ContactPoint[] contact = new ContactPoint[1];
            //owner.reflectWall[0].GetContacts(contact);

        }

        public override void OnUpdata(PlayerStateManager owner)
        {
            //反射するプログラムを書く


            print("反射する面:" + owner.reflectWallNormal.Count);
            //print(worldMousePos);

            //owner.transform.position = new Vector3(owner.transform.position.x + 0.01f, owner.transform.position.y, 0);
            
            print("vex" + owner.GetComponent<Rigidbody>().velocity);


            if (boundCount > 0)
            {
                //2面以上接しているときにどちらから計算するか入れ替えるべき？
/*                for (int i = 0; i < owner.reflectWallNormal.Count - 1; i++)
                {


                    float angle = Vector3.Angle(vec, owner.reflectWallNormal[i]);
                    float angle2 = Vector3.Angle(vec, owner.reflectWallNormal[i+1]);

                    if (angle < angle2)
                    {
                        Vector3 temp = owner.reflectWallNormal[i];
                        owner.reflectWallNormal[i] = owner.reflectWallNormal[i+1];
                        owner.reflectWallNormal[i + 1] = temp;


                    }
                }*/
                for (int i = 0; i < owner.reflectWallNormal.Count; i++)
                {

                    vec = Vector3.Reflect(vec, owner.reflectWallNormal[i]);

                    //owner.reflectWall = null;
                    owner.reflectWallNormal.Remove(owner.reflectWallNormal[i]);
                    boundCount--;
                    if(boundCount == 0)
                    {
                        break;
                    }
                }
                //owner.reflectWall.Clear();


            }

            owner.GetComponent<Rigidbody>().velocity = vec.normalized * owner.reflectSpeed;
            if(boundCount <=0)
            {
                boundCount = 0;
                owner.ChangeState(owner.moveState);
            }

            






            /*            if(boundCount != 0)
                        {
                            if (owner.reflectWall != null)
                            {
                                vec = Vector3.Reflect(owner.GetComponent<Rigidbody>().velocity.normalized, owner.reflectWall.contacts[0].normal);
                                owner.reflectWall = null;
                                boundCount--;
                            }
                        }
                        else
                        {
                            boundCount = 0;
                            owner.ChangeState(owner.moveState);
                        }*/

        }

        public override void OnExit(PlayerStateManager owner, PlayerStateBase prevState)
        {
            owner.GetComponent<TrailRenderer>().Clear();

        }
    }
}
