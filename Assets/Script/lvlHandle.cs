using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lvlHandle2 : MonoBehaviour {

	public int lvl;

	public Text test;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		test.text = ""+lvl;
	}


}
