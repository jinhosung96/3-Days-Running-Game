using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JHS
{    
    public class RunningTimeText : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("접두사")] string m_prefix;
        [SerializeField, LabelName("접미사")] string m_suffix;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            EventManager.Instance.AddListener("SetRunningTime", RefreshUIElement);
        }

        void OnEnable()
        {
            RefreshUIElement();
        }

        #endregion

        #region 외부 API

        public void RefreshUIElement()
        {
            GetComponent<TextMeshProUGUI>().text = $"{m_prefix}{(PlayerSystem.Instance.RunningTime/ 60).ToString("00")} : {(PlayerSystem.Instance.RunningTime % 60).ToString("00")}{m_suffix}";
        }

        #endregion
    }
}
