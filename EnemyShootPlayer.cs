using UnityEngine;
using System.Collections;

public class EnemyShootPlayer : MonoBehaviour {

		public Transform player;
		public float range = 50.0f;


		

		private bool onRange= false;
		
		public Rigidbody2D projectile;
		
		void Start(){
			float rand = Random.Range (1.0f, 1.1f);
			InvokeRepeating("Shoot", 1.1f, rand);
		}
		
		void Shoot(){
			
			if (onRange){
				
			Rigidbody2D bullet = (Rigidbody2D)Instantiate (projectile, transform.position, Quaternion.Euler (0, 0, 180));
			AudioController.instance.PlaySound(AudioController.AudioType.enemy_laser);
			}

				
		}
		
		void Update() {
			
			onRange = Vector2.Distance(player.position, player.position)<range;
		}
		
		
	}