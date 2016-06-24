using UnityEngine;
using System.Collections;

public class AddPointsOnAppear : MonoBehaviour {

    public int scoreValue;

    // Use this for initialization
    void Start () {
        var controller = GameObject.FindGameObjectWithTag("GameController");
        if (controller != null) {
            controller.GetComponent<GameController>().AddScore(scoreValue);
        }
    }


}
