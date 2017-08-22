using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class  PurchaseItem : MonoBehaviour {
    public int pointsNeeded;
    public string itemName;
    public Text infoText;
    public bool inRange;
    public bool purchased;

    public abstract void PurchaseAction();
    
    public void Purchase()
    {
        if (inRange)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                if(WaveSpawner.totalScore < pointsNeeded)
                {
                    purchased = true;
                    infoText.text = "";
                }
                else
                {
                    infoText.text = "Not enough points";
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            infoText.text = "Press Q to buy " + itemName +" Cost " + pointsNeeded + " points";
            inRange = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            infoText.text = "";
        }
    }
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Purchase();
        if (purchased)
        {
            PurchaseAction();
            purchased = false;

        }
    }        
}
