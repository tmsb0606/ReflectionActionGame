using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

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

        }

        public override void OnUpdata(PlayerStateManager owner)
        {
            //îΩéÀÇ∑ÇÈÉvÉçÉOÉâÉÄÇèëÇ≠


            //print(worldMousePos);

            //owner.transform.position = new Vector3(owner.transform.position.x + 0.01f, owner.transform.position.y, 0);
            owner.GetComponent<Rigidbody>().velocity =vec * owner.reflectSpeed;
            if (owner.reflectWall != null)
            {
                boundCount--;
                vec = Vector3.Reflect(owner.GetComponent<Rigidbody>().velocity.normalized, owner.reflectWall.contacts[0].normal);
                owner.reflectWall = null;
               
            }
            if(boundCount == -1)
            {
                boundCount = 0;
                owner.ChangeState(owner.moveState);
            }
        }

        public override void OnExit(PlayerStateManager owner, PlayerStateBase prevState)
        {
            owner.GetComponent<TrailRenderer>().Clear();

        }
    }
}
