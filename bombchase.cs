using UnityEngine;
using System.Collections;

public class bombchase : MonoBehaviour {

	public float speed = 2f;
	public float minDistance = 1f;
	private float range;
	public int damage = 1;
	public bool isEnemyBomb = true;
	public GameObject bomb_explosion;
	private CircleCollider2D myCollider;

	private GameObject player;

	void Start(){
				player = GameObject.Find ("Player");
				}

void FixedUpdate ()
	{
				range = Vector2.Distance (transform.position, player.transform.position);
		
				if (range > minDistance) {
						Debug.Log (range);
						transform.position = Vector2.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
				}
		Destroy (this.gameObject, 20);
		Debug.Log ("Destroy");

		}
void Update()
	{
					if (range <= minDistance)  
						
						{
								myCollider = transform.GetComponent<CircleCollider2D> ();
								myCollider.radius += 3f;
								Instantiate (bomb_explosion, transform.position, transform.rotation);
						}
						else {
						myCollider.enabled = false;
				}
								
						}
				
		

void Playbomb_explosion ()
		{
			GameObject explosion = (GameObject)Instantiate (bomb_explosion);
			explosion.transform.position = transform.position;
		}	
}