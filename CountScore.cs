using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountScore : MonoBehaviour {

	public Text scoreText;
	public static int scoreValue;
	[SerializeField]
	private int winScore;

	// Use this for initialization
	void Start () {
		//Set the score to zero
		scoreValue = 75;
		UpdateScoreText ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Alter the score
	public void UpdateScoreValue (int scoreUpdate){
		//Update the score
		scoreValue -= scoreUpdate;

		//Update the text of the score in the UI
		UpdateScoreText ();

		//Check if player has won
		if (scoreValue == winScore) {
			//Update the playerWin with the public player type variable.
			//ApplicationModel.playerWin = playerType;

			//Open the game over scene
			SceneManager.LoadScene("EndGame");
			Debug.Log("The game is over!");
		}
	}

	//Update the score in the game
	void UpdateScoreText (){
		scoreText.text = "Reputation: " + scoreValue;
	}

	//Reset score to zero
	void ResetScore (){
		scoreValue = 75;
		UpdateScoreText();
	}


}
