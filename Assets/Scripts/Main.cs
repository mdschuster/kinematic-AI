using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	World world;
	GameObject block1;
	GameObject block2;

	// Use this for initialization
	void Start () {

		world = new World ();

		block1 = GameObject.Find ("Cube1");
		block2 = GameObject.Find ("Cube2");

		block1.GetComponent<Mover> ().init ();
		block2.GetComponent<Mover> ().init ();


		if (block2.GetComponent<Mover> ().myKinematic==null) {
			Debug.Log ("NULL block character");
		}

		block1.GetComponent<AI> ().setAI ("Seek");
		block2.GetComponent<AI> ().setAI ("Wander");
		block1.GetComponent<AI> ().setTarget (block2.GetComponent<Mover>().myKinematic);

	}
	
	// Update is called once per frame
	void Update () {
	}
}
