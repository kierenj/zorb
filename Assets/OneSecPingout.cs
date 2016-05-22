using UnityEngine;
using System.Collections;

public class OneSecPingout : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var ls = GetComponent<RectTransform>().localScale;
        ls.x -= Time.deltaTime;
        ls.y -= Time.deltaTime;
        ls.z -= Time.deltaTime;
        GetComponent<RectTransform>().localScale = ls;
        if (ls.x <= 0)
        {
            Destroy(this);
        }
	}
}
