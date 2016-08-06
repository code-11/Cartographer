using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	float turnspeed = 5.0f;
	float speed = 5.0f;
	private float trueSpeed = 0.0f;
	float strafeSpeed = 5.0f;
	Rigidbody phyx;
	// Use this for initialization
	void Start () {
		 phyx = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
			float roll = Input.GetAxis("Roll");
			float pitch = Input.GetAxis("Pitch");
			float yaw = Input.GetAxis("Yaw");
			float movX=Input.GetAxis("Horizontal")*strafeSpeed*Time.deltaTime;
			float movY = Input.GetAxis ("Vertical") * strafeSpeed * Time.deltaTime;
			Vector3 strafe = new Vector3(movX,movY , 0);

			float power = Input.GetAxis("Power");

			//Truespeed controls

			if (trueSpeed < 10 && trueSpeed > -3){
				trueSpeed += power;
			}
			if (trueSpeed > 10){
				trueSpeed = 9.99f;	
			}
			if (trueSpeed < -3){
				trueSpeed = -2.99f;	
			}
			if (Input.GetKey("backspace")){
				trueSpeed = 0;
			}

			phyx.AddRelativeTorque(pitch*turnspeed*Time.deltaTime, yaw*turnspeed*Time.deltaTime, roll*turnspeed*Time.deltaTime);
			phyx.AddRelativeForce(0,0,trueSpeed*speed*Time.deltaTime);
			phyx.AddRelativeForce(strafe);
	}
}
