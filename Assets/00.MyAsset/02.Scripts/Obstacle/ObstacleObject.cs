using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class ObstacleObject : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("데미지")]float m_damage;

        #endregion

        #region 속성

        public float Damage => m_damage;

        #endregion
    }
}
