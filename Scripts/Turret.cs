using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	public Transform target;
	public Transform turretRotation;
	public float range = 15f;
	public string EnemyTag = "Enemy";
	Rigidbody bulletInstance;
	public Rigidbody bullet;
	public Transform bulletspawn;
	public float firingrate;
	public float delay;
	public int speed;
	public TextMesh HealthText;
	public int Health = 100;
	
	
	// Use this for initialization

	void Start () {
		InvokeRepeating("UpdateTarget",0f,0.5f);
	}
	void UpdateTarget(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
		GameObject nearestEnemy = null;
		float shorestDis = Mathf.Infinity;
		foreach (GameObject Enemy in enemies)
		{
			float disToEnemy = Vector3.Distance(transform.position, Enemy.transform.position);
			
			if(disToEnemy < shorestDis){
				shorestDis = disToEnemy;
				nearestEnemy = Enemy;
			}
		}
		if (nearestEnemy != null && shorestDis <= range){
			target = nearestEnemy.transform;
		}
		else
		{
			target = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Health <= 0){
			Destroy(gameObject);
		}
		if(target == null){
			return;
		}
		HealthText.text = "Health: " + Health;
		Vector3 direction = target.position - transform.position;
		Quaternion dirRotation = Quaternion.LookRotation(direction);
		Vector3 rotation = dirRotation.eulerAngles;
		turretRotation.rotation = Quaternion.Euler(-1.490116f, rotation.y, 0f);
		
		if ( Time.time > delay){
			bulletInstance = Instantiate(bullet, bulletspawn.position, bulletspawn.rotation) as Rigidbody;
			bulletInstance.AddForce (bulletspawn.forward * speed);
			delay = Time.time + firingrate;
	}
	}
	public void OnTriggerEnter(Collider boom)
	{

		//If the object that triggered this collision is tagged "Bullet"
		if (boom.gameObject.tag == "Enemy") {
			Health -= 10;
			}

		
		if (boom.gameObject.tag == "Enemy2") {
			Health -= 20;
			}
		
		}
}

