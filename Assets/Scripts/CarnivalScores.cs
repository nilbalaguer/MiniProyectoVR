using System;
using UnityEngine;
using TMPro;

public class CarnivalScores : MonoBehaviour {

	[SerializeField]
	private int TeddyBearPointsMin = 2000;

	[SerializeField]
	private GameObject TeddyBear;

	[SerializeField]
	private TextMeshPro plinkoScore;
	[SerializeField]
	private TextMeshPro wheelScore;
	[SerializeField]
	private TextMeshPro coinScore;

	public static CarnivalScores Instance;

	private int plinkoPoints;
	private int wheelPoints;
	private int coinPoints;

	void Awake() {
		if (Instance == null)
			Instance = this;

		if (TeddyBear != null)
			TeddyBear.SetActive(false);
		else
			Debug.LogWarning("CarnivalScores: TeddyBear no está asignado en el Inspector.");
	}

	void OnDestroy() {
		if (Instance == this)
			Instance = null;
	}

	void Update () {
		if (plinkoScore != null)
			plinkoScore.text = "Plinko: " + plinkoPoints.ToString("0000");
		if (wheelScore != null)
			wheelScore.text = "Wheel: " + wheelPoints.ToString("0000");
		if (coinScore != null)
			coinScore.text = "Coins: " + coinPoints.ToString("0000");

		if (TeddyBear != null && plinkoPoints + wheelPoints + coinPoints >= TeddyBearPointsMin) {
			TeddyBear.SetActive(true);
		}
	}

	public void IncrementPlinkoScore(float points) {
		plinkoPoints += (int) points;
	}

	public void IncrementWheelScore(float points) {
		wheelPoints += (int) points;
	}

	public void IncrementCoinScore() {
		coinPoints += 1000;
	}
}
