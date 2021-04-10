using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class SoundSystem : SceneObject<SoundSystem>
    {
        #region 변수

        [SerializeField, LabelName("점프 소리")] AudioClip m_jumpSound;
        [SerializeField, LabelName("코인 획득 소리")] AudioClip m_getCoinSound;
        [SerializeField, LabelName("회복 소리")] AudioClip m_healingSound;
        [SerializeField, LabelName("장애물 충돌 소리")] AudioClip m_crashSound;

        #endregion

        #region 속성

        public AudioClip JumpSound => m_jumpSound;
        public AudioClip GetCoinSound => m_getCoinSound;
        public AudioClip CrashSound => m_crashSound;
        public AudioClip HealingSound => m_healingSound;

        #endregion
    }
}
