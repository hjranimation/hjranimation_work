using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

		public Transform shotspawnB;
		public Transform shotspawnA;
		public Transform shotprefab;
		public float shootingRate = 0.25f;
		

		
		private float shootCooldown;

	void Awake(){
	}
		
		
	void Update()
	
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}

	public void Attack(bool isEnemy)
	{
				if (CanAttack) {
			AudioController.instance.PlaySound(AudioController.AudioType.fire);

						shootCooldown = shootingRate;
			
						// Create a new shot
						var shotTransform = Instantiate (shotprefab) as Transform;
			
						// Assign position
						shotTransform.position = shotspawnA.transform.position;

						// The is enemy property
						ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript> ();
						if (shot != null) {
								shot.isEnemyShot = isEnemy;
						}
						// Make the weapon shot always towards it
						MoveScript move = shotTransform.gameObject.GetComponent<MoveScript> ();
						if (move != null) {
								move.direction = this.transform.right; // towards in 2D space is the right of the sprite
						}
						
		} else {
			AudioController.instance.PlaySound(AudioController.AudioType.fire);

						// Create a new shot
						var shotTransform = Instantiate (shotprefab) as Transform;
			
						// Assign position
						shotTransform.position = shotspawnB.transform.position;
						// The is enemy property
						ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript> ();
						if (shot != null) {
								shot.isEnemyShot = isEnemy;
						}
						// Make the weapon shot always towards it
						MoveScript move = shotTransform.gameObject.GetComponent<MoveScript> ();
						if (move != null) {
								move.direction = this.transform.right; // towards in 2D space is the right of the sprite
						}
					
				}
	
	}


	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}