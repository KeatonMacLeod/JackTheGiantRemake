using UnityEngine;
using System.Collections;

public class CollectableScript : MonoBehaviour {

    //Called when the game object is activated
    void OnEnable()
    {
        //Function of MonoBehaviour
        Invoke("DestroyCollectable", 5f);
    }

    void DestroyCollectable()
    {
        gameObject.SetActive(false);
    }
}
