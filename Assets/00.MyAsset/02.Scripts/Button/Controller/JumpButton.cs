using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

namespace JHS
{ 
    [RequireComponent(typeof(ButtonController))]
    public class JumpButton : MonoBehaviour, IButtonClick
    {
        #region 콜백 함수

        public void OnClick()
        {
            if(PlayerSystem.Instance.StateMachine.CurrentState is IJumpable jumpableState)
            {
                jumpableState.OnJump();
            }
        }

        #endregion
    }
}
