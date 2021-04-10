using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class LoopRandomLevel : MonoBehaviour
    {
        #region 변수

        LevelObject m_currentLevel;
        [SerializeField] float m_scrollSpeed;
        [SerializeField] float m_endPosX;
        [SerializeField] float m_width;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            m_currentLevel = transform.GetChild(0).GetComponent<LevelObject>();
        }

        void Update()
        {
            MoveMap();
            Loop();
        }

        #endregion

        #region 구현부

        void MoveMap()
        {
            transform.Translate(-m_scrollSpeed * Time.deltaTime, 0f, 0f);
        }

        void Loop()
        {
            if (transform.position.x <= m_endPosX)
            {
                transform.Translate(m_width * 2, 0f, 0f);

                m_currentLevel.ItemsActiveOn();
                PoolManager.Instance.PushObject(m_currentLevel.gameObject);
                GameObject[] patterns = PatternSystem.Instance.Patterns;
                
                m_currentLevel = PoolManager.Instance.PopObject(patterns[Random.Range(0, patterns.Length)]).GetComponent<LevelObject>();
                m_currentLevel.transform.parent = this.transform;
                m_currentLevel.transform.localPosition = Vector3.zero;
            }
        }

        #endregion

        #region 디버깅

        [ContextMenu("자세한 정보")]
        public void DebugProperty()
        {
            Debug.Log($"m_currentLevel = {m_currentLevel}");
        }

        #endregion
    }
}
