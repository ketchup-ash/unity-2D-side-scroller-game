using UnityEngine;

public class meteor : MonoBehaviour {

    meteorSpawner m;
    playerController p;

    void Start() {
        GameObject g = GameObject.Find("EnemySpawner");
        m = g.GetComponent<meteorSpawner>();

        GameObject a = GameObject.Find("Player");
        p = a.GetComponent<playerController>();
    }

	void OnCollisionEnter2D(Collision2D obj) {
        if (obj.gameObject.tag == "Floor") {
            Destroy(gameObject);
            m.totalSpawned--;
        }

        if (obj.gameObject.tag == "Player") {
            Destroy(gameObject);
            m.totalSpawned--;
            p.score -= 50;
        }
    }


}
