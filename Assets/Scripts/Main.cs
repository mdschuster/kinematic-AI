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

		Mover b1Mover = block1.GetComponent<Mover> ();
		Mover b2Mover = block2.GetComponent<Mover> ();

		AI b1AI = block1.GetComponent<AI> ();
		AI b2AI = block2.GetComponent<AI> ();

		b1Mover.init ();
		b2Mover.init ();


		if (block2.GetComponent<Mover> ().myKinematic==null) {
			Debug.Log ("NULL block character");
		}

		b1AI.setAI ("Seek");
		b2AI.setAI ("Wander");
		b1AI.setSpeed (10f,10f);
		b2AI.setSpeed (10f,10f);
		b1AI.setTarget (b2Mover.myKinematic);
		b2AI.setTarget (b1Mover.myKinematic);

	}
	
	// Update is called once per frame
	void Update () {
	}
}
