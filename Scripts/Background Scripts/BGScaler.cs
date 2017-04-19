using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpriteRenderer renderTarget = GetComponent<SpriteRenderer>();
        Vector3 screenScale = transform.localScale;
        float width = renderTarget.bounds.size.x; //Get the width of the background
        float worldHeight = Camera.main.orthographicSize * 2;

        //Screen.width gives us the width of the screen when we click "Play" on our game.
        //Screen.height gives us the height of the screen when we click "Play" on our game.
        float worldWidth = worldHeight / Screen.height * Screen.width;
        screenScale.x = worldWidth / width;
        transform.localScale = screenScale;
	}

}
