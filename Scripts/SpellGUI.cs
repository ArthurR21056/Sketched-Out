using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellGUI : MonoBehaviour {
    public Image spell1,spell2, spell3;
    public static int  currentSpell;
    public LinkedList<Image> spellList = new LinkedList<Image>();
    

	// Use this for initialization
	void Start () {
        currentSpell = 0;
        spell1.enabled = true;
        spell2.enabled = false;
        spell3.enabled = false;
       
    }
	
	// Update is called once per frame
	void Update () {
        SwitchSpells(ref currentSpell);
	}

    void SwitchSpells(ref int i)
    {
        if (Input.GetKeyDown(KeyCode.C)){
            switch (i)
            {
                case 0:
                    spell1.enabled = false;
                    spell2.enabled = true;
                    i++;
                    break;
                case 1:
                    spell2.enabled = false;
                    spell3.enabled = true;
                    i++;
                    break;
                default:
                    spell3.enabled = false;
                    spell1.enabled = true;
                    i = 0;
                    break;
                }
                
            
            

        }
    }
}
