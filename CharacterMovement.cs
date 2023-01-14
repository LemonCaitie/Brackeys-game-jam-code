using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	[SerializeField]
	private float speed = 5.0f;
	float moveLimiter = 0.7f;

	//Called multiple times in a fixed time span
	void FixedUpdate (){
		//  This will return 1 when pressing either the W key, the UpArrow key, 
		//  or when pointing a gamepad's stick upwards. It will return -1 when using the S key, 
		//  the DownArrow key, or when pointing a gamepad's stick downwards. 
		var horizontal = Input.GetAxisRaw("Horizontal");
		var vertical = Input.GetAxisRaw("Vertical");
		if (horizontal != 0 && vertical != 0) // Check for diagonal movement
		{
			// limit movement speed diagonally, so you move at 70% speed
			horizontal *= moveLimiter;
			vertical *= moveLimiter;
		}
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (horizontal, vertical) * speed;
	}
}
