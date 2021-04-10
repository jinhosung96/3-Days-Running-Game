using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class RewardSystem : SceneObject<RewardSystem>
    {
        #region 변수

        int m_getCoin;

        #endregion

        #region 속성

        public int GetCoin
        {
            get => m_getCoin; 
            set
            {
                m_getCoin = value;
                EventManager.Instance.PostNofication("SetGetCoin");
            }
        }

        #endregion

        #region 유니티 생명주기

        new void Awake()
        {
            base.Awake();
        }

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        #endregion

        #region 외부 API



        #endregion

        #region 구현부

        #endregion
    }
}
