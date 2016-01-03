using UnityEngine;
using System.Collections;

public class Bonker : MonoBehaviour {

    private AudioSource clip;
    private AudioLowPassFilter filter;

    public void OnHit(float strength)
    {
        strength = Mathf.Clamp(strength / 17f, 0f, 1f);
        filter.cutoffFrequency = 150f + Mathf.Clamp(strength * 12000f, 0f, 50000f);
        clip.SetLoudness(strength);
        clip.Play();
    }

	// Use this for initialization
	void Start () {
        clip = GetComponent<AudioSource>();
        filter = GetComponent<AudioLowPassFilter>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
