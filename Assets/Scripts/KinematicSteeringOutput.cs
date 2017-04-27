using UnityEngine;
using System.Collections;

public class KinematicSteeringOutput {
	Vector3 velocity;
	float rotation;

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
