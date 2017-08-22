using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Barrier : MonoBehaviour {
	
	public Transform spawnPoint;
	public Transform barrier;
	public GameObject phantomBarrier;
	public Text infoText;
	public Collision item;
	public static int Ammo;
	public string ItemButtonName;
	public string ItemButtonDrop;
	public bool hasBarrier;
	
	
	private bool inRange;

	

	// Use this for initialization
	void Start () {
	phantomBarrier.GetComponent<MeshRenderer>().enabled = false;
	inRange = false;
	hasBarrier = false;

	}
	
	// Update is called once per frame
	void Update () {

		StartCoroutine(BarrierBuy());
		if(Input.GetButton(ItemButtonDrop) && hasBarrier == true && inRange == true ){
				Instantiate (barrier, spawnPoint.position , spawnPoint.rotation);
				phantomBarrier.GetComponent<MeshRenderer>().enabled = false;
				WaveSpawner.totalScore -= 1000;
				inRange = false;
				hasBarrier = false;
				infoText.text = "";
			}
		}
	
	void OnCollisionEnter(Collision item){
	if (item.gameObject.tag == "Store") {
			inRange = true;
			infoText.text = "Press Q to buy Turret. Cost 100 points";
			
		}
}
	IEnumerator BarrierBuy(){
		if (Input.GetButton (ItemButtonName) && inRange == true){
			if (WaveSpawner.totalScore < 1000){
			infoText.text = "Not Enough Points";
			inRange = false;
			yield return new WaitForSeconds (2f);
			infoText.text = "";
			}
		if (WaveSpawner.totalScore >= 1000){
			infoText.text = "Press E to place Turret";
			phantomBarrier.GetComponent<MeshRenderer>().enabled = true;
			hasBarrier = true;
			yield return new WaitForSeconds (1f);
		}
		
		}
	}
}