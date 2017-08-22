using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

	public Rigidbody spell1;                //Game object for basic spell   
    public Rigidbody spell2;                //Game object for advanced spell
    public Rigidbody spell3;                //Game object for super advanced spell

    public Transform bulletspawn;           //Position of the spawn of spells
    public static int spell1Mana;                  //Cost to cast spell 1
    public static int spell2Mana;                  //Cost to cast spell 2
    public static int spell3Mana = 0;              //Cost to cast spell 3 

	public int speed;                       //Speed of spell
    public static float ImaginDamage = 0;   //Spell damage
	public double firingrate;
    private AudioSource cast;
    public AudioClip fire1;
    public AudioClip fire2;

	// Use this for initialization
	void Start () {
	    cast = GetComponent<AudioSource>();
        spell1Mana = 3;
        spell2Mana = 5;
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) && ImaginationBar.Imagin != 0 && ImaginationBar.Imagin > 4 && SpellGUI.currentSpell == 0) {
            cast.PlayOneShot(fire1, .4f);
            CastSpell(spell1);

            ImaginationBar.AddDamage(spell1Mana);
                }
        if (Input.GetMouseButtonDown(0) && ImaginationBar.Imagin != 0 && ImaginationBar.Imagin > 4 && SpellGUI.currentSpell == 1) 
        {
            cast.PlayOneShot(fire2, .4f);
            CastSpell(spell2);
            ImaginationBar.AddDamage(spell2Mana);
        }

        if (Input.GetMouseButtonDown(0) && ImaginationBar.Imagin != 0 && ImaginationBar.Imagin > 4 && SpellGUI.currentSpell == 2)
        {
            CastSpell(spell3);
            ImaginationBar.AddDamage(spell3Mana);
        }

    }
    /*
     * Creates a spell with a certain speed 
     * @param bullet - The spell gameobject you want to spawn
     */
    public void CastSpell(Rigidbody bullet)
    {
        //Spawns bullet
        Rigidbody bulletInstance = Instantiate(bullet, transform.position, transform.parent.rotation) as Rigidbody;
        // AddForce to the copied bullet
        bulletInstance.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
    }
	}
