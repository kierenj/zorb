using UnityEngine;
using System.Collections;

public class ZorbController : MonoBehaviour {

    public float speed;
    public float jumpPow;
    public Camera cam;
    private Bonker bonker;
    private Rigidbody rb;
    private float lastHitTime;

    void Start () {
        rb = GetComponent<Rigidbody>();
        bonker = GetComponentInChildren<Bonker>();
	}

    void LateUpdate()
    {
        var roll = GetComponent<AudioSource>();
        roll.pitch = 0.3f + rb.angularVelocity.magnitude / 20.0f;
        roll.volume = Mathf.Clamp(rb.angularVelocity.magnitude / 18f, 0f, 0.6f);
        roll.volume = Mathf.Clamp(roll.volume, 0f, Mathf.Clamp(0.2f - lastHitTime, 0f, 1f));

        lastHitTime += Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        bonker.OnHit(col.relativeVelocity.magnitude);
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            lastHitTime = 0f;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");

        Vector3 movement = (cam.transform.forward * moveVertical + cam.transform.right * moveHorizontal) * speed + new Vector3(0, 1, 0) * jump * jumpPow;

        rb.AddForce(movement);
    }
}
