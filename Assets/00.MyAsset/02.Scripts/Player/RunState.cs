using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class RunState : State, IJumpable, ISlideable
    {
        #region 변수

        [SerializeField, LabelName("애니메이터")] Animator m_animator;
        [SerializeField, LabelName("점프 상태")] State m_jumpState;
        [SerializeField, LabelName("슬라이드 상태")] State m_slideState;

        #endregion

        #region 콜백 함수

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태로 진입했을 때 1회 실행
        public override void OnEnter()
        {
            m_animator.SetBool("IsRun", true);
        }       

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태에서 나갈 때 1회 실행
        // StopAllCourtine() 등 실행
        public override void OnExit()
        {
            m_animator.SetBool("IsRun", false);
        }

        public void OnJump()
        {
            if (m_machine.CurrentState == this)
            {
                m_machine.SetState(m_jumpState);
            }
        }

        public void OnSlide()
        {
            if (m_machine.CurrentState == this)
            {
                m_machine.SetState(m_slideState);
            }
        }

        #endregion
    }
}
