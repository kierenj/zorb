using UnityEngine;
using System.Collections;

public class SpawnPrefabOnDestroy : MonoBehaviour {

    public AudioClip deathSound;
    public GameObject deathObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnDestroy()
    {
        Instantiate(deathObject, transform.position, new Quaternion());
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }
}
