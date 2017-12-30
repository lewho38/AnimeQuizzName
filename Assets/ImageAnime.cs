using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnime : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string path = string.Format("LVL/imgs/{0}", Scenes.Id);
        transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
