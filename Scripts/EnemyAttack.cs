using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// A behavior class for when Enemies attack the player
public class EnemyAttack : MonoBehaviour {
    public int damage;          //The amount of damage the enemy will cause
    public float delay;         //Holds a time stamp to control attack rate
    public float attackRate;    //The rate the enemy will attack
    public Transform player;    //The main character
    public bool inrange;        //determines if the enemy is in range to attack

    //Controls if the enemy is in range
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inrange = true;
            delay = Time.time + .5f;
        }
    }
    // Controls if the enemy is out of range
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inrange = false;
        }
    }
    //Attacks the player
    public void Attack()
    {
        if(Time.time > delay)
        {
            delay = Time.time + attackRate;
            PlayerHealth.TakeDamage(damage);
        }
    }
    // Use this for initialization
    void Start () {
        attackRate = 2;
        delay = Time.time;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inrange = false;
	}
	
	// Update is called once per frame
	void Update () {
    
        if (inrange)
        {
            Attack();
        }

	}
}
