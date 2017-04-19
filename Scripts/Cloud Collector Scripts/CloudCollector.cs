using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

    //When the collider has "isTrigger" checked, this is the function that gets called
    //when any other game object touches this CloudCollector.
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Cloud" || target.tag == "Deadly")
        {
            target.gameObject.SetActive(false);
        }
    }
}
