using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class characterStore : MonoBehaviour {

    public Transform spawnPoint;
    public Transform barrier;
    public GameObject phantomBarrier;
    public Text infoText;
    public Collision item;
    public static int Ammo;
    public string ItemButtonName;
    public string ItemButtonDrop;
    public bool hasBarrier;
    public float range = 10f;
    public Transform player;
    float DisToPlayer;

    public bool isturret;
    public bool isAmmo;

    private bool inRange;



    // Use this for initialization
    void Start()
    {
        //makes the barrier invisible 
        phantomBarrier.GetComponent<MeshRenderer>().enabled = false;
        inRange = false;
        hasBarrier = false;
        DisToPlayer = Vector3.Distance(transform.position, player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {   
        //calcaulates the 3d distance from the store
        DisToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //starts the BarrierBuy function
        StartCoroutine(BarrierBuy(isturret));
        StartCoroutine(AmmoBuy(isAmmo));
    }

    IEnumerator AmmoBuy(bool isAmmo)
    {
        if (DisToPlayer <= range && isAmmo)
        {
            inRange = true;
            infoText.text = "Press Q to buy Ammo. Cost 50 points";
        }
        if (Input.GetButton(ItemButtonName) && inRange == true)
        {
            if (WaveSpawner.totalScore < 50)
            {
                infoText.text = "Not Enough Points";
                inRange = false;
                yield return new WaitForSeconds(2f);
                infoText.text = "";
            }
            if (WaveSpawner.totalScore >= 50)
            {

                infoText.text = "";
            }
        }
    }

    IEnumerator BarrierBuy(bool isturret)
    {

        if (DisToPlayer <= range && hasBarrier == false && isturret )
        {
            inRange = true;
            infoText.text = "Press Q to buy Turret. Cost 150 points";

        }
        if (Input.GetButton(ItemButtonName) && inRange == true)
        {
            if (WaveSpawner.totalScore < 150)
            {
                infoText.text = "Not Enough Points";
                inRange = false;
                yield return new WaitForSeconds(2f);
                infoText.text = "";
            }
            if (WaveSpawner.totalScore >= 150)
            {
                infoText.text = "Press E to place Turret";

                phantomBarrier.GetComponent<MeshRenderer>().enabled = true;
                hasBarrier = true;
            }
            if (Input.GetButton(ItemButtonDrop) && hasBarrier == true && inRange == true)
            {
                Instantiate(barrier, spawnPoint.position, spawnPoint.rotation);
                phantomBarrier.GetComponent<MeshRenderer>().enabled = false;
                WaveSpawner.totalScore -= 150;

                inRange = false;
                hasBarrier = false;
                infoText.text = "";
            }
            if (DisToPlayer >= range && hasBarrier == false)
            {
                infoText.text = "";
            }

        }
    }
   
}
