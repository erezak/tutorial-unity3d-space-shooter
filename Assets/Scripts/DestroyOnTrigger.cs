using UnityEngine;
using System.Collections;

public class DestroyOnTrigger : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController _controller;

    void Start() {
        var controller = GameObject.FindGameObjectWithTag("GameController");
        if (controller!=null) {
            _controller = controller.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Boundary")) {
            return;
        }

        // Explode self
        Instantiate(explosion, transform.position, transform.rotation);

        // If player, explode as well
        if (other.gameObject.CompareTag("Player")) {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        } else if (_controller != null) {
            _controller.AddScore(scoreValue);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
