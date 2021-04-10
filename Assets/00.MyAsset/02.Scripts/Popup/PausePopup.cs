using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class PausePopup : MonoBehaviour
    {
        #region 유니티 생명주기

        void OnEnable()
        {
            Pause(true);
        }

        void OnDisable()
        {
            Pause(false);
        }

        #endregion

        #region 구현부
        
        public void Pause(bool _isPause)
        {
            if (_isPause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        #endregion
    }
}