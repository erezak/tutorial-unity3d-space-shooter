using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    public float tumble;
    private Rigidbody _rb;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
        _rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
