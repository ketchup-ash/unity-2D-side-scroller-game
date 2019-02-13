using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    playerController playerCon;
    public TextMeshProUGUI scoreText;

    void Start() {
        GameObject player = GameObject.Find("Player");
        playerCon = player.GetComponent<playerController>();
    }
	
    void Update() {
        scoreText.text = "Score:" + playerCon.score.ToString();
    }

}
