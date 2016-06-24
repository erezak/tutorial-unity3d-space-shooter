using UnityEngine;
using System.Collections;

public class DestroyOnTrigger : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Boundary")) {
            return;
        }

        // Explode self
        Instantiate(explosion, transform.position, transform.rotation);

        // If player, explode as well
        if (other.gameObject.CompareTag("Player")) {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
