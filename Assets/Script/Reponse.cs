using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Reponse : MonoBehaviour {

    public Button btn;
    public float spacing = 2f;
    public float totalSize = 0f;
    private float w_btn; //width button
    private string nom = Scenes.Nom;
	void Start () {
        w_btn = btn.image.rectTransform.sizeDelta.x;
        //Calcul de la size total que vont prendre les boutons, {possible erreur}
        totalSize = nom.Length * w_btn + nom.Length-1 * spacing; // -1 car le dernier n'a pas de spacing
        //Calcul de la nouvelle position pour centrer le tout {possible erreur}
        float startPos = totalSize / -2 + w_btn / 2;
        for (int i=0;i<nom.Length;i++)
        {
            if (!nom[i].Equals(" "))
            { 
                Button b = Instantiate<Button>(btn);
                b.GetComponentInChildren<TextMeshProUGUI>().text = "";
                b.transform.SetParent(transform);
                b.transform.localPosition = new Vector3(startPos + i * (spacing+w_btn), 0, 0);// + w_btn car entre 2 boutons à côté il y'a w_btn d'écart <= transform.position =centre du bouton)
            }
        }
	}
	
}
