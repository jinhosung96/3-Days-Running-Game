using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class JumpState : State, IJumpable
    {
        #region 변수

        float yVelocity = 0;
        [SerializeField, LabelName("애니메이터")] Animator m_animator;
        [SerializeField, LabelName("중력")] float gravity;
        [SerializeField, LabelName("점프력")] float jumpPower;
        [SerializeField, LabelName("달리기 상태")] State m_runState;
        [SerializeField, LabelName("이단 점프 상태")] State m_doubleJumpState;

        #endregion

        #region 속성

        #endregion

        #region 콜백 함수   

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태로 진입했을 때 1회 실행
        public override void OnEnter()
        {
            m_animator.SetBool("IsJump", true);
            SoundManager.Instance.PlaySoundEffect(SoundSystem.Instance.JumpSound);
            yVelocity = jumpPower;
        }        

        // 유니티 생명주기 상의 Update에서 실행
        // 스테이트 머신의 현 상태가 본 상태일 때만 실행
        protected override void OnUpdate()
        {
            Jump();
        }

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태에서 나갈 때 1회 실행
        // StopAllCourtine() 등 실행
        public override void OnExit()
        {
            yVelocity = 0;
            m_animator.SetBool("IsJump", false);
        }

        public void OnJump()
        {
            if (m_machine.CurrentState == this)
            {
                m_machine.SetState(m_doubleJumpState);
            }
        }

        #endregion

        #region 구현부

        private void Jump()
        {
            yVelocity -= gravity * Time.deltaTime;
            transform.Translate(0, yVelocity * Time.deltaTime, 0);
            Land();
        }

        private void Land()
        {
            if (transform.position.y <= 0)
            {
                Vector3 pos = transform.position;
                pos.y = 0;
                transform.position = pos;

                m_machine.SetState(m_runState);
            }
        }

        #endregion
    }
}
