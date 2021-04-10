using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class SlideState : State, IJumpable, ISlideCanclable
    {
        #region 변수

        [SerializeField, LabelName("애니메이터")] Animator m_animator;
        [SerializeField, LabelName("달리기 상태")] State m_runState;
        [SerializeField, LabelName("점프 상태")] State m_jumpState;
        BoxCollider m_collider;

        #endregion

        #region 콜백 함수

        protected override void OnAwake()
        {
            m_collider = GetComponent<BoxCollider>();
        }

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태로 진입했을 때 1회 실행
        public override void OnEnter()
        {
            m_animator.SetBool("IsSlide", true);
            m_collider.size = new Vector3(1f, 1f, 1f);
            m_collider.center = new Vector3(0f, 0.5f, 0f);
        }

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태에서 나갈 때 1회 실행
        // StopAllCourtine() 등 실행
        public override void OnExit()
        {
            m_animator.SetBool("IsSlide", false);
            m_collider.size = new Vector3(1f, 2f, 1f);
            m_collider.center = new Vector3(0f, 1f, 0f);
        }

        public void OnSlideCancle()
        {
            if (m_machine.CurrentState == this)
            {
                m_machine.SetState(m_runState);
            }
        }

        public void OnJump()
        {
            if (m_machine.CurrentState == this)
            {
                m_machine.SetState(m_jumpState);
            }
        }

        #endregion
    }
}
