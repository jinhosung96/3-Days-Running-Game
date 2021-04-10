using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class PatternSystem : SceneObject<PatternSystem>
    {
        #region 변수

        [SerializeField] GameObject[] m_patterns;

        #endregion

        #region 속성

        public GameObject[] Patterns { get => m_patterns; set => m_patterns = value; }

        #endregion
    }
}
