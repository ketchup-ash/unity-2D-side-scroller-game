using UnityEngine;

public class itemSpawner : MonoBehaviour {

    private int i;
    playerController playerCon;

    private Vector3[] itemLocation = new Vector3[] {
        new Vector3(-4.63f, 3f),
        new Vector3(-4f, -1.46f),
        new Vector3(-0.4f, -0.46f),
        new Vector3(3.6f, 1.6f),
        new Vector3(5.7f, -2.66f),
        new Vector3(10.4f, -1.16f),
        new Vector3(11.8f, 3.84f),
        new Vector3(15.8f, 0.42f),
        new Vector3(18.3f, -3.46f),
        new Vector3(20.2f, 2.74f),
        new Vector3(21.5f, -1.88f)
    };

    void Start() {
        Place();
        GameObject player = GameObject.Find("Player");
        playerCon = player.GetComponent<playerController>();
    }

    void OnTriggerEnter2D(Collider2D obj) {
        if(obj.CompareTag("Player")) {
            Place();
            playerCon.score += 10;
        }
    }

    void Place() {
        int j = i;
        do {
            i = Random.Range(0, 10);
        } while (j == i);
        transform.position = itemLocation[i];
    }
}
