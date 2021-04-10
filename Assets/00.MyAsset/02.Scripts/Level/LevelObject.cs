using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class LevelObject : MonoBehaviour
    {
        #region 변수

        List<GameObject> m_items = new List<GameObject>();

        #endregion

        #region 공개 속성

        public List<GameObject> Items => m_items;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            
        }

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        #endregion

        #region 외부 API

        public void ItemsActiveOn()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].SetActive(true);
            }
        }

        #endregion

        #region 구현부



        #endregion
    }
}
