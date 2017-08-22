using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImaginationPotion : MonoBehaviour {
    public int addMana;       //The value added caused by Imagination potion
    private AudioSource pickup;
    public AudioClip hit;

    private void Start()
    {
        pickup = GetComponent<AudioSource>();
    }
    /*
     * Adds Imagination to players Imagination and destorys gameobject 
     * when collision with player happens
     * @param other - any Collider that touches this gameobjects collider
     */
    public void OnTriggerEnter(Collider other)
    {
        pickup.PlayOneShot(hit, .4f);
        if (other.tag == "Player")
        {
            if (ImaginationBar.Imagin > (ImaginationBar.MaxImagin - addMana))
                ImaginationBar.Imagin = 100;
  
            else
                ImaginationBar.Imagin += addMana;

            Destroy(gameObject);
        }
    }
}
