using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour {

    private float x, y, z;
	// Use this for initialization
	void Start () {
        x = UnityEngine.Random.Range(0.2f, 2f);
        y = UnityEngine.Random.Range(0.2f, 2f);
        z = UnityEngine.Random.Range(0.2f, 2f);
        transform.Rotate(new Vector3(x * 100f, y * 100f, z * 100f));
    }
	
	// Update is called once per frame
	void Update () {
        var a = Time.deltaTime * 250f;
        transform.Rotate(new Vector3(a*x,a*y,a*z));
	}
}
