using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class CoinObject : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("레벨")] LevelObject m_level;

        [SerializeField, LabelName("코인 획득량")] int m_coin;
        [SerializeField, LabelName("코인 이펙트")] GameObject m_coinEffect;


        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            m_level.Items.Add(this.gameObject);
        }

        #endregion

        #region 외부 API

        public void Rooting()
        {
            gameObject.SetActive(false);
            RewardSystem.Instance.GetCoin += m_coin;
            SoundManager.Instance.PlaySoundEffect(SoundSystem.Instance.GetCoinSound);
            Instantiate(m_coinEffect).transform.position = transform.position;
        }

        #endregion
    }
}
