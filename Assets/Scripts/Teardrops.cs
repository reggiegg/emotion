using UnityEngine;
using System.Collections;

public class Teardrops : MonoBehaviour {

	float FILL_SPEED = 0.005f;

	private ParticleSystem.CollisionEvent[] collisionEvents = new ParticleSystem.CollisionEvent[16];
	float initialEmissionRate;
	void OnParticleCollision(GameObject other) {

		if (other.name == "WaterCollider") {
			Transform spriteTransform = other.transform.Find("WaterSprite");
			FillableWaterBody waterBody = (FillableWaterBody)other.GetComponent("FillableWaterBody");

			Vector3 spriteStartScale = waterBody.spriteStartScale;
			float expectedHeight = spriteStartScale.y * ((Player)GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(Player))).Sadness;
			if (spriteTransform.localScale.y < expectedHeight) {
				int safeLength = particleSystem.safeCollisionEventSize;
				if (collisionEvents.Length < safeLength) {
					collisionEvents = new ParticleSystem.CollisionEvent[safeLength];
				}
				
				int numCollisionEvents = particleSystem.GetCollisionEvents(other, collisionEvents);
				int i = 0;
				while (i < numCollisionEvents) {
					spriteTransform.localPosition += new Vector3(0, FILL_SPEED * 3);
					spriteTransform.localScale += new Vector3(0, FILL_SPEED);
					i++;
				}
			}
		}

	}

	// Use this for initialization
	void Start () {
		initialEmissionRate = particleSystem.emissionRate;
		particleSystem.emissionRate = 0;
	}
	
	// Update is called once per frame
	void Update () {
		particleSystem.emissionRate = ((Player)GameObject.FindGameObjectWithTag ("Player").GetComponent (typeof(Player))).Sadness * initialEmissionRate;
	}
}
