using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class LoopObject : MonoBehaviour
    {
        #region 변수

        [SerializeField] float m_scrollSpeed;
        [SerializeField] float m_endPosX;
        [SerializeField] float m_width;

        #endregion

        #region 유니티 생명주기

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
            if(transform.position.x <= m_endPosX)
            {
                transform.Translate(m_width * 2, 0f, 0f);
            }
        }

        #endregion
    }
}
