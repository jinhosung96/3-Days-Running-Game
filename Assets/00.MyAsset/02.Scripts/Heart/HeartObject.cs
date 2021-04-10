using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class HeartObject : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("레벨")] LevelObject m_level;

        [SerializeField, LabelName("회복량")] int m_healing;

        [SerializeField, LabelName("회전 속도")] float m_speed;
        [SerializeField, LabelName("회전 속도")] GameObject m_heartEffect;


        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            m_level.Items.Add(this.gameObject);
        }

        private void Update()
        {
            transform.Rotate(Vector3.up * m_speed * Time.deltaTime);
        }

        #endregion

        #region 외부 API

        public void Rooting()
        {
            gameObject.SetActive(false);
            PlayerSystem.Instance.CurrentHealth += m_healing;
            SoundManager.Instance.PlaySoundEffect(SoundSystem.Instance.HealingSound);
            Instantiate(m_heartEffect).transform.position = transform.position;
        }

        #endregion
    }
}
