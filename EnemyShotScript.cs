using UnityEngine;
using System.Collections;

public class EnemyShotScript : MonoBehaviour {		
		
		public int damage = 1;
		public bool isEnemyShot = true;
		
		
		void Start()
		{
			Destroy(gameObject, 15); // 20sec
		}
	}