using UnityEngine;
using System.Collections;

public class BGCollector : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Background")
        {
            target.gameObject.SetActive(false);
        }//if

    }//OnTriggerEnter2D

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
