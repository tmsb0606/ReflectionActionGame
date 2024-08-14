using UnityEngine;
public partial class PlayerStateManager
{
    public class PlayerMoveState : PlayerStateBase
    {
        
        public override void OnEnter(PlayerStateManager owner, PlayerStateBase prevState)
        {
            boundCount = 10;
            print(boundCount);
        }
        public override void OnUpdata(PlayerStateManager owner) {
            //�����ɃL�[�{�[�h����ړ��┽�˕����𑀍삷��v���O����������


            //����ŃX�e�[�g�ύX
            owner.ChangeState(owner.reflectionState);
        
        }

        public override void OnExit(PlayerStateManager owner, PlayerStateBase prevState) { 
        
        
        }
    }
}
