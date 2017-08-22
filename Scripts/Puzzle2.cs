using UnityEngine;
using System.Collections;

public class Puzzle2 : MonoBehaviour {
	public Transform Turret;
	public Transform spawnPoint1;
	public Transform spawnPoint2;
	public Transform spawnPoint3;
	public Transform spawnPoint4;
	public Transform spawnPoint5;
	public Transform spawnPoint6;


	public bool A_Trigger;
	public bool B_Trigger;
	

	// Use this for initialization
	void Start () {
	B_Trigger = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	A_Trigger = puzzle.A_Trigger;
	}
	public void OnTriggerEnter(Collider boom)
	{
		//If the object that triggered this collision is tagged "Bullet"
		if (boom.gameObject.tag == "Bullet" && B_Trigger!= true && A_Trigger ==true) {
				B_Trigger = true;
				Instantiate (Turret, spawnPoint1.position, spawnPoint1.rotation);	
				Instantiate (Turret, spawnPoint2.position, spawnPoint1.rotation);
				Instantiate (Turret, spawnPoint3.position, spawnPoint1.rotation);
				Instantiate (Turret, spawnPoint4.position, spawnPoint1.rotation);
				Instantiate (Turret, spawnPoint5.position, spawnPoint1.rotation);
				Instantiate (Turret, spawnPoint6.position, spawnPoint1.rotation);	
			}

		}
}