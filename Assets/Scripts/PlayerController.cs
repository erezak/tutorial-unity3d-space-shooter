using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}

public class PlayerController : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalSpeed;

    public float tilt;

    public GameObject shot;
    public Transform shotSpawnPoint;

    public float shotsInterval;
    private float nextAllowedShot = 0.0f;

    public Boundary boundary;

    private Rigidbody _rb;
    private AudioSource _audio;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        // Fire
        if (Input.GetButton("Fire1") && Time.time > nextAllowedShot) {
            Instantiate(shot, shotSpawnPoint.position, shotSpawnPoint.rotation);
            nextAllowedShot = Time.time + shotsInterval;

            _audio.Play();
        }
	}

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal") * horizontalSpeed;
        float moveVertical = Input.GetAxis("Vertical") * verticalSpeed;

        _rb.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rb.position = new Vector3(
            Mathf.Clamp(_rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(_rb.position.z, boundary.zMin, boundary.zMax)
        );

        _rb.rotation = Quaternion.Euler(0.0f, 0.0f, _rb.velocity.x * -tilt);
    }
}
