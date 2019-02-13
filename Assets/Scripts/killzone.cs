using UnityEngine;
using UnityEngine.SceneManagement;

public class killzone : MonoBehaviour {

    meteorSpawner m;

    void Start() {
        GameObject g = GameObject.Find("EnemySpawner");
        m = g.GetComponent<meteorSpawner>();
    }

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.CompareTag("Player")) {
            Destroy(obj.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (obj.CompareTag("Meteor")) {
            Destroy(obj.gameObject);
            m.totalSpawned--;
        }
    }
}
