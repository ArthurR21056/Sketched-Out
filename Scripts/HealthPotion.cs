using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {
    public int addHealth;       //The value added caused by health potion
    private AudioSource pickup;
    public AudioClip hit;

    private void Start()
    {
        pickup = GetComponent<AudioSource>();
    }
    /*
     * Adds health to players health  and destorys gameobject 
     * when collision with player happens
     * @param other - any Collider that touches this gameobjects collider
     */
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pickup.PlayOneShot(hit, .4f);
            if (PlayerHealth.Health > (PlayerHealth.MaxHealth - addHealth))
                PlayerHealth.Health = 100;

            else
                PlayerHealth.Health += addHealth;

            Destroy(gameObject);
        }
    }
}
