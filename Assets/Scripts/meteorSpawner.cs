using UnityEngine;

public class meteorSpawner : MonoBehaviour {

    public GameObject meteor;
    public Transform parent;

    private Vector3 position;
    public int spawnCount;
    [HideInInspector]public int totalSpawned;

    void Start() {
        position = parent.position;
    }

    void Update() {
        position.x = Random.Range(-7, 24);
        if (totalSpawned < spawnCount) {
            Instantiate(meteor, position, Quaternion.identity, parent);
            totalSpawned++;
        }
    }

}
