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


		if (block2.GetComponent<Mover> ().MyKinematic==null) {
			Debug.Log ("NULL block character");
		}
		world.init (block1.GetComponent<Mover>().MyKinematic,block2.GetComponent<Mover>().MyKinematic);
	}
	
	// Update is called once per frame
	void Update () {
		world.update ();
	}
}
