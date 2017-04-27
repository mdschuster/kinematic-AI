using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public Kinematic MyKinematic;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 ();
		pos = MyKinematic.Position;
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
		MyKinematic.Position = pos;
		this.transform.position=pos;
		this.transform.eulerAngles = new Vector3 (0f, MyKinematic.Orientation*180f/Mathf.PI, 0f);
		//Debug.Log ("BLOCK POSITION: " + pos);


	}

	public void init(){
		MyKinematic=new Kinematic();
		MyKinematic.Position = this.transform.position;
		MyKinematic.Velocity = new Vector3 (0f, 0f, 0f);
		MyKinematic.Rotation = 0f;
		MyKinematic.Orientation = 0f;
	}
}
