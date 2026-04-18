using UnityEngine;

public class CoinTossCoin : MonoBehaviour {

    public delegate void CoinLandedAction();
    public static event CoinLandedAction OnCoinMissed;

    void OnCollisionEnter(Collision other) {
        if (OnCoinMissed != null && !other.gameObject.CompareTag("CoinToss")) {
            OnCoinMissed();
        }
    }
}
