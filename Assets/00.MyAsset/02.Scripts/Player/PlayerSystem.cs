using Doozy.Engine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JHS
{    
    public class PlayerSystem : SceneObject<PlayerSystem>
    {
        #region 변수

        [SerializeField, LabelName("플레이어")] GameObject m_player;
        [SerializeField, LabelName("생명력 슬라이더")] Slider m_healthSlider;

        [SerializeField, LabelName("최대 생명력")] float m_maxHealth;
        float m_currentHealth;
        [SerializeField, LabelName("초당 생명력 감소")] float m_perDamage;
        int m_runningTime;

        #endregion

        #region 속성

        public GameObject GameObject => m_player;
        public Transform Transform => m_player.transform;
        public StateMachine StateMachine => m_player.GetComponent<StateMachine>();
        public Slider HealthSlider => m_healthSlider;
        public float CurrentHealth 
        { 
            get => m_currentHealth;
            set
            {
                if(value <= m_maxHealth)
                {
                    m_currentHealth = value;
                }
                else
                {
                    m_currentHealth = m_maxHealth;
                }
                m_healthSlider.value = CurrentHealth / m_maxHealth;
                if(m_currentHealth <= 0)
                {
                    UIPopup.GetPopup("Result").Show();
                }
            }
        }
        public int RunningTime 
        { 
            get => m_runningTime;
            set
            {
                m_runningTime = value;
                EventManager.Instance.PostNofication("SetRunningTime");
            }
        }

        #endregion

        #region 유니티 생명주기

        new void Awake()
        {
            base.Awake();
            ResetGame();
        }

        void Start()
        {
            StartCoroutine(Co_DemagePerSecond());
            StartCoroutine(Co_RunningTime());
        }

        #endregion

        #region 외부 API



        #endregion

        #region 구현부

        private void ResetGame()
        {
            CurrentHealth = m_maxHealth;
            m_healthSlider.value = 1;
        }

        IEnumerator Co_DemagePerSecond()
        {
            while (CurrentHealth > 0)
            {
                yield return null;
                CurrentHealth -= m_perDamage * Time.deltaTime;
            }
        }
        IEnumerator Co_RunningTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                RunningTime++;
            }
        }

        #endregion
    }
}
