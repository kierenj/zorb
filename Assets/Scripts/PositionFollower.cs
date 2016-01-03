using UnityEngine;
using System.Collections;

public class PositionFollower : MonoBehaviour
{
    public GameObject target;
	
	void Update()
    {
        transform.position = target.transform.position;
	}
}
