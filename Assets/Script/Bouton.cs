using UnityEngine;
using System.Collections;

public class Bouton : MonoBehaviour {

	public int idBut;

	public InterfaceTR ParleAuHandleFDP;

	// Use this for initialization
	void Start () {
		
		ParleAuHandleFDP = FindObjectOfType<InterfaceTR>();

		int.TryParse (gameObject.name,out idBut);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void test(){
		ParleAuHandleFDP.GetComponent<InterfaceTR> ().lvlselect = idBut;
	}
}
