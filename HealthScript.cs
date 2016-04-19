using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HealthScript : MonoBehaviour {

	public int hp = 1;
	public bool isEnemy = true;
	public GameObject explosion_trigger;
	public Slider hpbar;


	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
			// Dead!
			PlayExplosion();
			AudioController.instance.PlaySound(AudioController.AudioType.explosion);
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		EnemyShotScript shot = otherCollider.gameObject.GetComponent<EnemyShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);
				hpbar.value = (hp);
				
				// Destroy the shot
				PlayExplosion();
				Destroy(shot.gameObject);
			}

		}
		bombchase bomb = otherCollider.gameObject.GetComponent<bombchase> ();
		if (bomb != null) {
			if (bomb.isEnemyBomb!= isEnemy) {
				Damage (bomb.damage);
				hpbar.value = (hp);
			}
		}
		addhealth health = otherCollider.gameObject.GetComponent<addhealth> ();
		if (health != null){
			if (health.isHealth != isEnemy) {
				Damage (health.damage);
				hpbar.value = (hp);
				Destroy (health.gameObject);
			}
	}
	}
	void PlayExplosion ()
	{
				GameObject explosion = (GameObject)Instantiate (explosion_trigger);
		explosion.transform.position = transform.position;
	}
	}