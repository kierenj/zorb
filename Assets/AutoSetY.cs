using UnityEngine;
using System.Collections;

public class AutoSetY : MonoBehaviour {

	// Use this for initialization
	void Start () {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, Vector3.down, out hit)) return;
        transform.position = hit.point + Vector3.up * 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}