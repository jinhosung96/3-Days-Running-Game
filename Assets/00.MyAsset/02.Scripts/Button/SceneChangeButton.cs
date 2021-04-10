using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

namespace JHS
{    
    public class SceneChangeButton : MonoBehaviour, IButtonClick
    {
        #region 변수

        [SerializeField, LabelName("변경할 씬 이름")] string m_nextSceneName;

        #endregion

        #region 콜백 함수

        public void OnClick()
        {
            SceneManager.Instance.LoadScene(m_nextSceneName, SCENE_CHANGE_TYPE.Fade);
        }

        #endregion
    }
}
