using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

    private Rigidbody _rb;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * speed;
    }
	
}
