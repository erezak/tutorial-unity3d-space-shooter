using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;

    public int spawnCount;
    public float spawnWaitInWave;
    public float spawnWaitBetweenWaves;
    public float startWait;

    private int _score;
    private bool _restart;
    private bool _gameOver;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnWaves());

        StartGame();
    }

    void Update() {
        if (_restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void StartGame() {
        _score = 0;
        UpdateScore();
        _gameOver = false;
        _restart = false;
        restartText.text = "";
        gameOverText.text = "";
    }

    private void UpdateScore() {
        scoreText.text = "Score: " + _score;
    }

    public void AddScore(int scoreToAdd) {
        _score += scoreToAdd;
        UpdateScore();
    }

    public void GameOver() {
        _gameOver = true;
        gameOverText.text = "Game Over";
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
            if (_gameOver) {
                break;
            }
        }

        // Because we wait until the loop is done, the player won't see the restart game option immediately
        _restart = true;
        restartText.text = "Press 'R' to restart";
    }
}
