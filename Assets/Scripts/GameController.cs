using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;

    public int spawnCount;
    public float spawnWaitInWave;
    public float spawnWaitBetweenWaves;
    public float startWait;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < spawnCount; i++) {
                var hazardPosition = new Vector3();
                hazardPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
                hazardPosition.y = spawnValues.y;
                hazardPosition.z = spawnValues.z;
                Instantiate(hazard, hazardPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWaitInWave);
            }
            yield return new WaitForSeconds(spawnWaitBetweenWaves); 
        }
    }
}
