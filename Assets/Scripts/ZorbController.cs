using UnityEngine;
using System.Collections;

public class ZorbController : MonoBehaviour
{
    public float speed;
    public float jumpPow;
    public Camera cam;
    public RunController run;

    private ZorbCollisionNoisemaker hitNoiser;
    private Rigidbody rb;
    private float lastHitTime;

    void Start () {
        rb = GetComponent<Rigidbody>();
        hitNoiser = GetComponentInChildren<ZorbCollisionNoisemaker>();
	}

    void LateUpdate()
    {
        var roll = GetComponent<AudioSource>();
        roll.pitch = 0.3f + rb.angularVelocity.magnitude / 20.0f;
        roll.volume = Mathf.Clamp(rb.angularVelocity.magnitude / 18f, 0f, 0.6f);
        roll.volume = Mathf.Clamp(roll.volume, 0f, Mathf.Clamp(0.2f - lastHitTime, 0f, 1f));

        lastHitTime += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        hitNoiser.OnHit(col.relativeVelocity.magnitude);
    }

    void OnCollisionStay(Collision col)
    {
        lastHitTime = 0f;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");

        Vector3 movement = (cam.transform.forward * moveVertical + cam.transform.right * moveHorizontal) * speed;

        if (run.EnableControls)
        {
            //rb.angularVelocity *= 0.8f;
            rb.AddTorque(cam.transform.right * moveVertical * speed);
            rb.AddTorque(cam.transform.forward * -moveHorizontal * speed);
            rb.AddForce(new Vector3(0, 1, 0) * jump * jumpPow);
        }
    }
}
