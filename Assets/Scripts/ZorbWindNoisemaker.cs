using UnityEngine;
using System.Collections;

public class ZorbWindNoisemaker: MonoBehaviour
{
    private AudioSource wind;
    private Rigidbody rb;

	void Start()
    {
        wind = GetComponent<AudioSource>();
        rb = GetComponentInParent<Rigidbody>();
    }
	
	void Update()
    {
        wind.volume = Mathf.Clamp((rb.velocity.magnitude - 2f) / 60f, 0f, 1f);
	}
}
