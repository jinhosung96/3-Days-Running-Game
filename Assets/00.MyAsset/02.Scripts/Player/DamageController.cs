using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class DamageController : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("무적 시간")] float m_invincibleDuration;
        [SerializeField] Renderer[] m_renderers;

        #endregion

        #region 콜백 함수

        private void OnTriggerEnter(Collider other)
        {
            ObstacleObject obstacle = other.GetComponent<ObstacleObject>();
            if (obstacle)
            {
                PlayerSystem.Instance.CurrentHealth -= obstacle.Damage;
                SoundManager.Instance.PlaySoundEffect(SoundSystem.Instance.CrashSound);
                StartCoroutine(Co_Invincible());
            }
        }

        #endregion

        #region 구현부

        IEnumerator Co_Invincible()
        {
            GetComponent<Collider>().enabled = false;
            for (int i = 0; i < m_invincibleDuration; i++)
            {
                for (int j = 0; j < m_renderers.Length; j++)
                {
                    m_renderers[j].material.DOColor(new Color(1, 0.5f, 0.5f, 1), 0.5f);
                }
                yield return new WaitForSeconds(0.5f);
                for (int j = 0; j < m_renderers.Length; j++)
                {
                    m_renderers[j].material.DOColor(Color.white, 0.5f);
                }
                yield return new WaitForSeconds(0.5f);
            }
            GetComponent<Collider>().enabled = true;
        }

        #endregion
    }
}
