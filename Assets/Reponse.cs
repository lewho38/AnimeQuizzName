using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class Reponse : MonoBehaviour {

    public Button btn;
    public float spacing = 2f;
    public float totalSize = 0f;
    private float w_btn; //width button
    private string nom = Scenes.Nom;
    private List<Button> lb = new List<Button>();
	void Start () {
        w_btn = btn.image.rectTransform.sizeDelta.x;
        spacing += w_btn;
        for (int i=0;i<nom.Length;i++)
        {
            if (!nom[i].Equals(" "))
            { 
                Button b = Instantiate<Button>(btn);
                b.GetComponentInChildren<TextMeshProUGUI>().text = nom[i].ToString();
                b.transform.SetParent(transform);
                b.transform.localPosition = new Vector3(i * spacing, 0, 0);
                lb.Add(b);
            }
            totalSize += spacing;
        }
        SetPos();
	}
	
	// Update is called once per frame
	private void SetPos()
    {
        float startPos = (Screen.width - totalSize)/-2;
        int length = lb.Count;
        for (int i=0;i<length;i++)
        {
                lb[i].transform.position += new Vector3(startPos,0,0);
        }
    }
}
