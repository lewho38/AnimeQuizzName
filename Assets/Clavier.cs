using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Clavier : MonoBehaviour {

    // Use this for initialization
    public float offSetX = 40;
    
    public Button btn_clavier;
	void Start () {
        offSetX += btn_clavier.image.rectTransform.sizeDelta.x / 2f; //Pour prendre en compte la taille du bouton
        float totalWidth = Screen.width - offSetX * 2;//offSetX*2 pour prend que ce soit offset à gauche et à droite
        float startPos = (totalWidth) /-2;
        float ecart = (totalWidth / 6);
        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < 6; i++)
            {
                Button b = Instantiate<Button>(btn_clavier);
                b.transform.SetParent(transform);
                b.transform.localPosition = new Vector3(startPos + i*ecart, k*40, 0);
            }
        }
	}
	
}
