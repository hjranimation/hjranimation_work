using UnityEngine;
using System.Collections;

public class addhealth : MonoBehaviour {


	public int damage = 1;
	public bool isHealth = true;


	void Start()
	{
		Destroy(gameObject, 15); // 20sec
	}
}