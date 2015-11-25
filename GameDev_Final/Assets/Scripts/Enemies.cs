using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {

	Rigidbody rb;
	public Transform target;
	public Transform[] pt;
	public int wanderIndex;
	
	private float t = 60.0f;
	private float walkSpeed = 2.0f;
	private float runSpeed = 5.0f;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (t > 0.0f) {
//			t -= Time.deltaTime;
//			if ( t < 30.0f){
//				moveSpeed = 4;
//				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(target.position - transform.position), .2f);
//				transform.position += transform.forward * moveSpeed * Time.deltaTime;
//			}
//		}
		if (t > 0.0f) 
		{
			t -= Time.deltaTime;
			if (t > 30.0f) 
			{
				if (transform.position.x >= pt[wanderIndex].position.x && transform.position.z >= pt[wanderIndex].position.z)
				{
					wanderIndex = Random.Range (0, pt.Length);
				}
				Wandering (wanderIndex);
			}
			if (t < 30.0f)
			{
				Chasing();
			}
		}
	}

	void Chasing ()
	{	
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(target.position - transform.position), .2f);
		transform.position += transform.forward * runSpeed * Time.deltaTime;
	}
	
	void Wandering (int idx)
	{
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(pt[idx].position - transform.position), .2f);
		transform.position += transform.forward * walkSpeed * Time.deltaTime;
	}


}