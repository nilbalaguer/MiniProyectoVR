using System.Collections;
using UnityEngine;
using TMPro;

public class CarnivalNeedle : MonoBehaviour {

    public Animator tickAnimation;

    public delegate void NeedleAction(float points);
    public static event NeedleAction OnSpokeHit;

    private GameObject prevHit = null;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject != prevHit) {
            if (tickAnimation != null)
                tickAnimation.SetTrigger("tick");

            if (OnSpokeHit != null) {
                var tmp = other.transform.parent.GetComponent<TextMeshPro>();
                if (tmp != null)
                    OnSpokeHit(float.Parse(tmp.text));
            }

            prevHit = other.gameObject;
        }
    }
}
