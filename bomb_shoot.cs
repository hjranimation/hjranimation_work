using UnityEngine;
using System.Collections;

public class bomb_shoot : MonoBehaviour {

	// Use this for initialization
	public Transform player;
	public Transform shotspawnA;

	public float shootingrate;

	public float range;
	private float _lastShotTime = float.MinValue;
	public bool inRange = false;

	public Transform projectile;
	
	void Start(){
		}

	void OnTriggerExit2D(Collider2D other)
	{
		inRange = false;
		}

	void OnTriggerEnter2D(Collider2D obj)
	{
		//put your aggro code in here
		inRange = true;
		}


void Update()
	{
		//Fire at player when in range.
		//distance = Vector2.Distance(transform.position, GameObject.Find ("Player").transform.position);
		
		if (/*distance < range*/ inRange && Time.time > _lastShotTime + (1f / shootingrate))
	//if (inRange)
		{
			_lastShotTime = Time.time;
			shootbomb ();
			AudioController.instance.PlaySound(AudioController.AudioType.enemy_hit);
		}    
	}
	
void shootbomb()
	{
		var bomb = Instantiate (projectile) as Transform;
		bomb.position = shotspawnA.transform.position;

				}

void fixedupdate() {

		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0)
		{
			Destroy(this.gameObject);
			Debug.Log("Destroy");
		}
	}
		
}