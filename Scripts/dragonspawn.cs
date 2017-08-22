using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dragonspawn : MonoBehaviour {
	public Transform Dragon;

	public Transform item1_mesh;
	public Transform item2_mesh;

	public Transform Dragonspawn;
	public bool item1;
	public bool item2;
	public Text infoText;
	public string ItemButtonName;
	public bool dragonHasSpawned;
	public bool inrange;
	public bool keydown;

	// Use this for initialization
	void Start () {
	inrange = false;
	dragonHasSpawned = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("q")){
			keydown = true;
	}
		else
	{
			keydown = false;
	}
		if(keydown == true && inrange == true && dragonHasSpawned == false){
					Instantiate (Dragon, Dragonspawn.position , Dragonspawn.rotation);
					dragonHasSpawned = true;
				}
	}
	public void OnTriggerEnter(Collider boom)
	{
		//If the object that triggered this collision is tagged "item1"
		if (boom.gameObject.tag == "item1" ) {
				Destroy(boom.gameObject);
				item1 = true;	
			}
		if (boom.gameObject.tag == "item2" ) {
				Destroy(boom.gameObject);
				item2 = true;	
			}
		if (boom.gameObject.tag == "DragonCraft" ) {
				if(item1 == true && item2 == true ){
					inrange = true;
				}
				
				
			}

		}

}