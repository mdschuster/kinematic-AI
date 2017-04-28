using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public Kinematic myKinematic;
	KinematicSteeringOutput steering;
	AI myAI;

	// Use this for initialization
	void Start () {
		myAI = GetComponent<AI> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 ();
		pos = myKinematic.Position;
		steering = myAI.getSteering (this.myKinematic);
		myKinematic.update (steering,Time.deltaTime);
		pos = myKinematic.Position;
		//check boundaries
		if (pos.x > 25.0f) {
			pos.x = -25.0f;
		}
		if (pos.x < -25.0f) {
			pos.x = 25.0f;
		}

		if (pos.z > 25.0f) {
			pos.z = -25.0f;
		}
		if (pos.z < -25.0f) {
			pos.z = 25.0f;
		}
		myKinematic.Position = pos;
		this.transform.position=pos;
		this.transform.eulerAngles = new Vector3 (0f, myKinematic.Orientation*180f/Mathf.PI, 0f);
		//Debug.Log ("BLOCK POSITION: " + pos);


	}

	public void init(){
		myKinematic=new Kinematic();
		myKinematic.Position = this.transform.position;
		myKinematic.Velocity = new Vector3 (0f, 0f, 0f);
		myKinematic.Rotation = 0f;
		myKinematic.Orientation = 0f;
	}
		
}
