using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class Clavier : MonoBehaviour {

    // Use this for initialization
    public float offSetX = 40;
    public int columns = 6;
    public int lines = 2;
    /* debug */
    public float ecart;
    public float totalWidthDispo;
    public float totalWidth;
    /* */
    public Button btn_clavier;
    private float w_btn;
    private List<Button> lb = new List<Button>();
    void Start ()
    {
        w_btn = btn_clavier.image.rectTransform.sizeDelta.x;
        totalWidthDispo = Screen.width - offSetX * 2;//offSetX*2 pour prend que ce soit offset à gauche et à droite
        totalWidth = columns * w_btn;
        ecart = w_btn + (totalWidthDispo - totalWidth)/ (columns-1); // -1 : il y'a n-1 écart pour n bouton
        float startPos = (totalWidthDispo) /-2 + w_btn/2;
        
        for (int k = 0; k < lines; k++)
        {
            for (int i = 0; i < columns; i++)
            {
                Button b = Instantiate<Button>(btn_clavier);
                b.transform.SetParent(transform);
                b.transform.localPosition = new Vector3(startPos + i*ecart, k*40, 0);
                lb.Add(b);
            }
        }
        GenerateLetters();
    }

    void GenerateLetters()
    {
        string nom = Scenes.Nom;
        
        for(int i=0; i<nom.Length;i++)
        {
            int length = lb.Count;
            int rand_numb = Random.Range(0, length-1);
            lb[rand_numb].GetComponentInChildren<TextMeshProUGUI>().text = nom[i].ToString();
            lb.RemoveAt(rand_numb);
        }
        foreach(var b in lb)
        {
            b.GetComponentInChildren<TextMeshProUGUI>().text = ((char)('A' + Random.Range(0, 26))).ToString();
        }
    }
	
}
