using UnityEngine;
using System.Collections;

public class Kinematic {

	//kinematic variables
	Vector3 position;
	float orientation;
	Vector3 velocity;
	float rotation;


	public void update(KinematicSteeringOutput steering, float dt){
		//update position and orientation
		position += steering.Velocity * dt;
		orientation += steering.Rotation * dt;
		//and the velocity and rotation
		//velocity += steering.Velocity * dt;
		//rotation += steering.Rotation * dt;
	}

	public Vector3 Position {
		get {
			return position;
		}
		set {
			position = value;
		}
	}

	public float Orientation {
		get {
			return orientation;
		}
		set {
			orientation = value;
		}
	}

	public Vector3 Velocity {
		get {
			return velocity;
		}
		set {
			velocity = value;
		}
	}

	public float Rotation {
		get {
			return rotation;
		}
		set {
			rotation = value;
		}
	}
}
