using UnityEngine;
using System.Collections;

public class WindNoiser : MonoBehaviour {

    private AudioSource wind;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        wind = GetComponent<AudioSource>();
        rb = GetComponentInParent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        wind.volume = Mathf.Clamp((rb.velocity.magnitude - 2f) / 60f, 0f, 1f);
	}
}
