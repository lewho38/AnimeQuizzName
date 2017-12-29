using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InterfaceTR : MonoBehaviour {

    public int NbLvl;

    public GameObject boutonLvlPrefab;

    public GameObject layout;

    public RectTransform layoutRect;

	public lvlHandle lvlSc;

	public GameObject mainSc;

    private int cellsup;

	public int lvlselect;

    // Use this for initialization
    void Start () {

		lvlSc = FindObjectOfType<lvlHandle> ();

        if (NbLvl > 15)
        {
            //RectTransform
            //layoutRect.rect.yMax = (Mathf.Ceil((NbLvl - 15) / 3) * 233) + 18;

            int Lim = 15 + 3;
            cellsup = 1;
            while (NbLvl > Lim)
            {
                cellsup++;
                Lim += 3;
            }
        }

        setupLvl();

        float tempheight = 1176 + (cellsup * 236);

        Debug.Log(tempheight);

        layoutRect.sizeDelta = new Vector2(720,tempheight);

        layoutRect.position = new Vector3(layoutRect.position.x, 0);

        tempheight /= -2;

        Debug.Log(tempheight);

        //layoutRect.position.Set(layoutRect.position.x, tempheight, 0);
        layoutRect.anchoredPosition.Set(layoutRect.position.x, tempheight);

		lvlSc.gameObject.SetActive (false);
    }
	
	// Update is called once per frame
	void Update () {
		if (lvlselect!=0) {
			lvlSc.lvl = lvlselect;
			lvlSc.gameObject.SetActive (true);
			mainSc.SetActive (false);
			lvlselect = 0;
		}
    }


    public void setupLvl()
    {

        for (int i = 0; i < NbLvl; i++)
        {
            var temp = Instantiate(boutonLvlPrefab);

           
            temp.name = "" + (i+1);

            temp.GetComponentInChildren<Text>().text = "" + (i + 1);

            temp.transform.parent = layout.transform;

            temp.transform.localScale = new Vector3(2.2f, 2.2f, 1);

        }

    }

	public void backMainMenu(){
		lvlSc.gameObject.SetActive (false);

		mainSc.SetActive (true);
	}
}
