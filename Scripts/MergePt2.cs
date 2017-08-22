using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergePt2 : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject Kingbert;
    public Collider boom;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter(boom);
    }
    public void OnTriggerEnter(Collider boom)
    {
        if (boom.gameObject.tag == "Enemy")
        {
            Instantiate(Kingbert, spawnPoint.position, spawnPoint.rotation);
        }
    }
}