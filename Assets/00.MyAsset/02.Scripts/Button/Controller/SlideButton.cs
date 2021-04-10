using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

namespace JHS
{    
    [RequireComponent(typeof(ButtonController))]
    public class SlideButton : MonoBehaviour, IButtonPointerDown, IButtonPointerUp
    {
        #region 변수

        bool m_isButtonDown;

        #endregion

        #region 유니티 생명주기

        void Update()
        {
            if (m_isButtonDown)
            {
                if (PlayerSystem.Instance.StateMachine.CurrentState is ISlideable slideableState)
                {
                    slideableState.OnSlide();
                }
            }
        }

        #endregion

        #region 콜백 함수

        public void OnPointerDown()
        {
            m_isButtonDown = true;
        }

        public void OnPointerUp()
        {
            m_isButtonDown = false;
            if (PlayerSystem.Instance.StateMachine.CurrentState is ISlideCanclable slideCanclableState)
            {
                slideCanclableState.OnSlideCancle();
            }
        }

        #endregion
    }
}
