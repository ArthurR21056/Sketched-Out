using UnityEngine;
using System.Collections;

public class puzzle : MonoBehaviour {
	public Transform Turret;
	public Transform spawnPoint1;
	public Transform spawnPoint2;
	public Transform spawnPoint3;
	public Transform spawnPoint4;
	public Transform spawnPoint5;
	public Transform spawnPoint6;


	public static bool A_Trigger;
	

	// Use this for initialization
	void Start () {
	A_Trigger = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	StartCoroutine(Timelimit());
	}
	public void OnTriggerEnter(Collider boom)
	{
		//If the object that triggered this collision is tagged "Bullet"
		if (boom.gameObject.tag == "Bullet" && A_Trigger!= true) {
				A_Trigger = true;
		}

		}
	IEnumerator Timelimit()
	{
		if(A_Trigger == true){
			yield return new WaitForSeconds (5f);
			A_Trigger = false;
		}
	}
}
