using UnityEngine;
using System.Collections;

public abstract class KinematicAICore{
	//holds data for char and target
	Kinematic character;
	Kinematic target;

	//holds max speed
	float maxspeed;
	float maxrotation;
	float radius=0.1f;
	float timeToTarget=0.5f;

	protected abstract Vector3 getTargetVector (Vector3 charPos, Vector3 targetPos);
	protected abstract Vector3 getVelocity (KinematicSteeringOutput steering);
	protected abstract float getRotation ();

	public KinematicSteeringOutput getSteering(){
		//create steering object
		KinematicSteeringOutput steering = new KinematicSteeringOutput ();

		//set the direction to target
		if (character == null) {
			Debug.Log ("NULL character");
		}
		if(target==null){
			Debug.Log("NULL target");
		}

		steering.Velocity = getTargetVector (character.Position, target.Position);

		//steering.Linear=target.Position-character.Position;
		//Debug.Log ("1 " +steering.Velocity);

		//the velocity is along this direction, at full speed
		steering.Velocity=getVelocity(steering);
		//steering.Velocity *= maxspeed;

		//steering.Velocity=getArrive (steering);
		if (steering.Velocity.magnitude == 0f) {
			return steering;
		}

		//face in direction we want to move //FIXME
		character.Orientation=getNewOrientation(steering);

		//output the steering
		steering.Rotation=getRotation();
		//Debug.Log (steering.Rotation);

		return steering;
	}

	public float getNewOrientation(KinematicSteeringOutput steering){
		if (this.character.Velocity.magnitude == 0) {
			return (float)Mathf.Atan2 (steering.Velocity.x, steering.Velocity.z);
		} else {
			return this.character.Orientation;
		}
	}
		

	public Kinematic Character {
		get {
			return character;
		}
		set {
			character = value;
		}
	}

	public Kinematic Target {
		get {
			return target;
		}
		set {
			target = value;
		}
	}

	public float Maxspeed {
		get {
			return maxspeed;
		}
		set {
			maxspeed = value;
		}
	}

	public float Maxrotation {
		get {
			return maxrotation;
		}
		set {
			maxrotation = value;
		}
	}

	public float Radius {
		get {
			return radius;
		}
		set {
			radius = value;
		}
	}

	public float TimeToTarget {
		get {
			return timeToTarget;
		}
		set {
			timeToTarget = value;
		}
	}
}


public class KinematicSeek : KinematicAICore{

	protected override Vector3 getTargetVector (Vector3 charPos, Vector3 targetPos)
	{
		return targetPos-charPos;
	}

	protected override Vector3 getVelocity (KinematicSteeringOutput steering)
	{
		//old jittery way
		//return steering.Velocity.normalized*base.Maxspeed;

		//new arrive way
		if (steering.Velocity.magnitude < base.Radius) {
			return new Vector3(0f,0f,0f);
		}
		steering.Velocity /= base.TimeToTarget;
		if (steering.Velocity.magnitude > base.Maxspeed) {
			return steering.Velocity.normalized * base.Maxspeed;
		}
		return steering.Velocity;
	}

	protected override float getRotation(){
		return 0f;
	}

}

public class KinematicFlee : KinematicAICore{

	protected override Vector3 getTargetVector (Vector3 charPos, Vector3 targetPos)
	{
		return charPos-targetPos;
	}

	protected override Vector3 getVelocity (KinematicSteeringOutput steering)
	{
		return steering.Velocity.normalized*base.Maxspeed;
	}

	protected override float getRotation(){
		return 0f;
	}
}


public class KinematicWander : KinematicAICore{

	protected override Vector3 getTargetVector (Vector3 charPos, Vector3 targetPos)
	{
		return new Vector3 (0f, 0f, 0f);
	}
		
	protected override Vector3 getVelocity (KinematicSteeringOutput steering)
	{

		//return steering.Velocity.normalized*base.Maxspeed;
		Vector3 vec= new Vector3(Mathf.Sin(Character.Orientation),0f,Mathf.Cos(Character.Orientation));
		steering.Velocity = vec;
		return base.Maxspeed*steering.Velocity.normalized ;

	}

	protected override float getRotation(){
		float randNum;

		randNum = randomBinomial();
		return randNum * base.Maxrotation;
	}

	protected float randomBinomial()
	{
		//random binomial from book
		return Random.Range(0f,1f)-Random.Range(0f,1f);
	}

}