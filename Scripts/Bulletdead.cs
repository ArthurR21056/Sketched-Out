using UnityEngine;
using System.Collections;

public class Bulletdead : MonoBehaviour {
	public int life = 0; 

	// Use this for initialization
	void Start () {
        
	}

	// Update is called once per frame
	void Update () {
        Deathtime();
	}
	public void OnTriggerEnter(Collider boom)
	{
		//If the object that triggered this collision is tagged "Enemy"
		if (boom.gameObject.tag == "Enemy") {
            
            Destroy (gameObject);
		}
		//If the object that triggered this collision is tagged "Scene"
		if (boom.gameObject.tag == "Scene") {
				Destroy (gameObject);
		}
	}
    public void Deathtime()
    {
        Destroy(gameObject, 1.2f);

    }

}


