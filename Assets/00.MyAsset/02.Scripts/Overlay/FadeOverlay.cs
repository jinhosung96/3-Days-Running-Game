using Doozy.Engine.UI;
using System;
using System.Collections;
using UnityEngine;

namespace JHS
{
    public class FadeOverlay : MonoBehaviour
    {
        #region 변수

        string m_nextSceneName;

        #endregion

        #region 외부 API

        public void Show(string _nextSceneName)
        {
            m_nextSceneName = _nextSceneName;
            GetComponent<UIPopup>().Show();
        }

        #endregion

        #region 콜백 함수

        public void OnShowFinishedTrigger()
        {
            StartCoroutine(ChangeScene());
        }

        #endregion

        #region 구현부

        void Hide()
        {
            GetComponent<UIPopup>().Hide();
            m_nextSceneName = String.Empty;
        }

        IEnumerator ChangeScene()
        {
            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(m_nextSceneName);
            while (!async.isDone)
            {
                yield return null;
            }
            Hide();
        } 

        #endregion
    } 
}
