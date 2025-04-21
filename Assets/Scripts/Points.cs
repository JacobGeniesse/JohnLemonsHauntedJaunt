using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
	public int score = 0;
	public TextMeshProUGUI scoreText;

	public void addPoints(int earnedScore){
		score = score + earnedScore;
        scoreText.text = "Points: " + score;
	}
}
