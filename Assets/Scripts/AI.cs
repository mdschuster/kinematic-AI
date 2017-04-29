using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour{

	//Baisc AI Script for use with unity object
	KinematicAICore AICore;
	Kinematic target;
	KinematicSteeringOutput KSO;

	//overloaded initializers
	public void init(KinematicAICore AICore){
		this.AICore=AICore;
	}

	public void init(KinematicAICore AICore, Kinematic target){
		this.AICore = AICore;
		this.target = target;
	}

	public void init(){
		this.AICore=new KinematicWander();
	}

	//set a new target for the AI
	public void setTarget(Kinematic target){
		this.target = target;
	}

	public Kinematic getTarget(){
		return this.target;
	}

	//Change the AI type, must be a kind of KinematicAICore
	public void setAI(KinematicAICore AICore){
		if (this.AICore != null) {
			this.AICore = null;
		}
		this.AICore = AICore;
	}
	//sets new AI based on string name \\FIXME use a dictionary instead?
	public void setAI(string AICore){
		if (this.AICore != null) {
			this.AICore = null;
		}
		if (AICore == "Seek") {
			this.AICore = new KinematicSeek ();
		} else if (AICore == "Flee") {
			this.AICore = new KinematicFlee ();
		} else {
			this.AICore = new KinematicWander ();
		}
	}

	public KinematicSteeringOutput getSteering(Kinematic self){
		if (this.target == null) {
			//if there is no target, set it to yourself
			this.target = self;
		}
		KSO = AICore.getSteering(self,this.target);
		return this.KSO;
	}

	//allows setting the max speed and max rotation allowed by this AI
	public void setSpeed(float maxSpeed, float maxRotation){
		AICore.Maxspeed = maxSpeed;
		AICore.Maxrotation = maxRotation;
	}


}
