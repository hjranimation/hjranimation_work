﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
		
		public Vector2 speed = new Vector2(50, 50);
		private Vector2 movement;
		
		void Update()

		{
				// 3 - Retrieve axis information
				float inputX = Input.GetAxis ("Horizontal");
				float inputY = Input.GetAxis ("Vertical");
			
				// 4 - Movement per direction
				movement = new Vector2 (
				speed.x * inputX,
				speed.y * inputY);
		
		// 5 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		
		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)

			{
				// false because the player is not an enemy
				weapon.Attack(false);
			}
		}
		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);

}


void FixedUpdate()
		{
			// 5 - Move the game object
			GetComponent<Rigidbody2D>().velocity = movement;
		}

}