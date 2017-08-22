using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class turret2 : MonoBehaviour {
	
	public Transform spawnPoint;
	public Transform barrier;
	public GameObject phantomBarrier;
	public Text infoText;
	public bool hasBarrier;
    public bool inRange;
    public int points;

	// Use this for initialization
	void Start () {
	    phantomBarrier.GetComponent<MeshRenderer>().enabled = false;
	    hasBarrier = false;
        inRange = false;
    }
	
	// Update is called once per frame
	void Update () {
        points = WaveSpawner.totalScore;
        BuyTurret();
        PlaceBarrier();
        }

    public void OnTriggerEnter(Collider other)
    {
        infoText.text = "Press Q to buy Turret. Cost 150 points";
        inRange = true;
    }
    public void OnTriggerExit(Collider other)
    {
        if (hasBarrier == false)
        {
            infoText.text = "";
        }
    }
    public void PlaceBarrier()
    {
        if(hasBarrier == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Instantiate(barrier, spawnPoint.position, spawnPoint.rotation);
                phantomBarrier.GetComponent<MeshRenderer>().enabled = false;
                WaveSpawner.totalScore -= 150;
                hasBarrier = false;
                infoText.text = "";
            }
        }
    }
    public void BuyTurret()
    {
        if (Input.GetKey(KeyCode.Q) && inRange == true)
        {
            if (points >= 150)
            {
                infoText.text = "Press E to place Turret";
                phantomBarrier.GetComponent<MeshRenderer>().enabled = true;
                hasBarrier = true;
            }
            if (points < 150)
            {
                infoText.text = "Not Enough Points! Go Kill Some Monsters!";

            }
        }
    }
}
	