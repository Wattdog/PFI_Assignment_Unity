using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	
	public float speed;
	public Rigidbody rb;
	
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	void Update ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
		} else if (other.gameObject.tag == "DontPickUp") {
			other.gameObject.SetActive (false);
		}
	}
}
