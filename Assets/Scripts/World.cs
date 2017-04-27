using UnityEngine;
using System.Collections;

public class World {

	Kinematic character1;
	Kinematic character2;

	KinematicAICore seek;
	KinematicAICore flee;

	public void init (Kinematic cha1, Kinematic cha2){
		this.character1 = new Kinematic ();
		this.character2 = new Kinematic ();

		this.seek = new KinematicSeek ();
		this.flee = new KinematicWander ();

		this.character1 = cha1;
		this.character2 = cha2;

		seek.Character = this.character1;
		flee.Character = this.character2;
		seek.Maxspeed = 10f;
		flee.Maxspeed = 5f;
		seek.Maxrotation = 10f;
		flee.Maxrotation = 10f;

	}

	public void update(){
		KinematicSteeringOutput steer = new KinematicSteeringOutput ();
		this.seek.Target = this.flee.Character;
		steer = seek.getSteering ();
		//Debug.Log ("steering output: " + steer.Linear);
		character1.update (steer, Time.deltaTime);


		KinematicSteeringOutput Ksteer = new KinematicSteeringOutput ();
		this.flee.Target = this.seek.Character;
		Ksteer = flee.getSteering ();
		character2.update (Ksteer, Time.deltaTime);
	}
}
