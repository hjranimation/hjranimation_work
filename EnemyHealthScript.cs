using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class EnemyHealthScript : MonoBehaviour {
		
		
		public int hp = 1;
		public bool isEnemy = true;
		public bool isEnemyBomb = true;
		public GameObject explosion_trigger;
		public GameObject shot_hit;
		public int scoreValue;

	



//	public AudioSource explosionAudio;

		public void Damage(int damageCount)
		{
						
						hp -= damageCount;
						{

			
								if (hp <= 0) {
		
										// Dead!

										PlayExplosion ();
										AudioController.instance.PlaySound(AudioController.AudioType.explosion);
										Score.score += scoreValue;
										Destroy (gameObject);
										
								}
				
						}
				
		}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
		{
			// Is this a shot?
			ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				// Avoid friendly fire
				if (shot.isEnemyShot != isEnemy)
				{
					PlayBurst();
					Damage(shot.damage);
					
					// Destroy the shot
					Destroy(shot.gameObject);				}
			}
		}
	void OnTriggerEnter2D(CircleCollider2D otherCollider)
	{
		// Is this a shot?
		bombchase shot = otherCollider.gameObject.GetComponent<bombchase>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyBomb != isEnemy)
			{

			}
		}
		ShotScript blast = otherCollider.gameObject.GetComponent<ShotScript>();
		if (blast != null)
		{
			// Avoid friendly fire
			if (blast.isEnemyShot != isEnemy)
			{
				PlayBurst();
				Damage(blast.damage);
				
				// Destroy the shot
				Destroy(blast.gameObject);				}
		}
	}

	void PlayBurst ()
	{
		GameObject burst = (GameObject)Instantiate (shot_hit);
		burst.transform.position = transform.position;
	}
	void PlayExplosion ()
	{
		GameObject explosion = (GameObject)Instantiate (explosion_trigger);
		explosion.transform.position = transform.position;
		//if (explosionAudio != null) {
		//		}
	}	


	}