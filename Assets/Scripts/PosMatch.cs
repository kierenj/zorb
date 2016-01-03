using UnityEngine;
using System.Collections;

public class PosMatch : MonoBehaviour {

    public GameObject target;
	
	// Update is called once per frame
	void Update () {
        transform.position = target.transform.position;
	}
}
