using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {


	public float speed = 2f;
	private float minDistance = 0f;
	private float range;


	void FixedUpdate ()
	{
		range = Vector2.Distance(transform.position, GameObject.Find ("Player").transform.position);
		//Vector3 headingDirection = getHeadingDirection

		if (range > minDistance)
		{
			Debug.Log(range);
			transform.position = Vector2.MoveTowards(transform.position, GameObject.Find ("Player").transform.position, speed * Time.deltaTime);
			//myRigidBody.velocity = someSpeed * headingDirection
		}
	}
	}