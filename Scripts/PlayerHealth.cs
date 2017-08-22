using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Represents and controls the main Player's health
*/
public class PlayerHealth : MonoBehaviour {

    static public float MaxHealth;  //Max Health of Player
    static public float Health;     //Current Health of Player
    public Slider healthBar;        //GUI to repesent Health
    public Text healthText;         //GUI to repesent Health
    public float healthRegen;       //Amount that the player health will go up
    static public bool isdamaged;   //A flag to see if Player is attacked
    private float healthRegenDelay; //When the Regen function is called this is updated
    

    // Use this for initialization
    void Start()
    {
        MaxHealth = 100;
        healthRegenDelay = Time.time;
        Health = 100;
        healthText.text = "HP:   " + Health;
        healthRegen = 1;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HP:   " + Health;
        healthBar.value = Health;

        if (isdamaged)
        {
            //If is being attack it will updated health. Updates healthRegenDelay if player is attacked   
            isdamaged = false;
            healthText.text = "HP:   " + Health;
            healthBar.value = Health;
            healthRegenDelay = Time.time + 20;
        }
        if (healthRegenDelay < Time.time)
        {
            //Call RegenHealth only if the current time goes over the delay time
            RegenHealth();
        }
    }
    /* If health is not 100 update adds 1 to current health
    */
    public void RegenHealth()
    { 
        if (Health != 100 && Health < 100)
        {
            Health += healthRegen;
            healthRegenDelay += 1;
        }
    }
    /* Takes the damage of the enemy and subtracts it from the current health
     * @param damage - Damage of the attack enemy 
     */
    static public void TakeDamage(int damage)
    {
        isdamaged = true;
        Health = Health - damage;
    }

}

