using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class lvlHandle : MonoBehaviour {
    public int lvl;

    public string[] data;

    public GameObject B_perso;

    public GameObject layout;

    public Text test;

    public List<Sprite> Image_Perso; 

	// Use this for initialization
	void Start () {
        if (!File.Exists(@"Assets/Resources/LVL/cfgs/lvl1.cfg"))
        {
            File.WriteAllText(@"Assets/Resources/LVL/cfgs/lvl1.cfg", "");
        }
        else
        {
            data = File.ReadAllLines("Assets/Resources/LVL/cfgs/lvl1.cfg");
        }

        if (data.Length > 0)
        {
            for (int i = 0; i < data.Length; i++)
            {
                string s = string.Format("LVL/imgs/{0}", i+1);
                Image_Perso.Add(Resources.Load<Sprite>(s));
            }
        }

        init_perso(data,Image_Perso);

	}
	
	// Update is called once per frame
	void Update () {
		test.text = ""+lvl;
	}



    void init_perso(string[] d,List<Sprite> img)
    {
        for (int i = 0; i < d.Length; i++)
        {
            var temp = Instantiate(B_perso);
            temp.name = "" + (i + 1);
            temp.GetComponent<Image>().sprite = img[i];
            temp.transform.SetParent(layout.transform);


        }
    }
}
