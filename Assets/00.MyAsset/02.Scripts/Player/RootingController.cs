using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class RootingController : MonoBehaviour
    {
        #region 콜백 함수

        private void OnTriggerEnter(Collider other)
        {
            CoinObject coinObject = other.GetComponent<CoinObject>();
            if (coinObject != null)
            {
                coinObject.Rooting();
            }

            HeartObject heartObject = other.GetComponent<HeartObject>();
            if (heartObject != null)
            {
                heartObject.Rooting();
            }
        }

        #endregion
    }
}
