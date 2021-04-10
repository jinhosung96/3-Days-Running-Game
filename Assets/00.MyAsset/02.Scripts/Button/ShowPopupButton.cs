using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 대상 팝업을 출력 <para></para>
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. ButtonController 컴포넌트와 같이 사용해야 자동으로 버튼 클릭 트리거에 추가된다. <para></para>
    ///
    /// </summary>
    [RequireComponent(typeof(ButtonController))]
    #endregion
    public class ShowPopupButton : MonoBehaviour, IButtonClick
    {
        #region 변수

        [SerializeField, LabelName("대상 팝업")] string m_popupName;

        #endregion

        #region 콜백 함수

        public void OnClick()
        {
            UIPopup.GetPopup(m_popupName).Show();
        }

        #endregion
    }
}
