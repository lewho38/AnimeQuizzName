using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HandlerClick : MonoBehaviour {
    //map qui va contenir les boutons qui ont été désactivé
    //<int,GameObject>, int ? => Technique de professionnel qui va être expliqué
    static Dictionary<int, GameObject> obj_disable = new Dictionary<int, GameObject>();
    private Button[] btns;
    private void Start()
    {
        //On cherche l'objet Reponse contenant les boutons où l'on va devoir changer leurs txt
        //Dans le start pour éviter les pertes de perf si on appel ça à chaque clic
        //Cependant ça fais chelou car j'utilise ce script pour les boutons qui sont dans reponse, et pour eux
        //on s'en ballec de chercher Reponse
        Reponse reponse = transform.parent.parent.GetComponentInChildren<Reponse>();
        if(reponse!=null)
            btns = reponse.transform.GetComponentsInChildren<Button>();
    }
    public void ClavierEvent() //Pour le clavier
    {

        Button b = btns[0];
        //Tant qu'on a pas trouvé de boutons avec un texte vide
        for(int i=0; i < btns.Length && b.GetComponentInChildren<TextMeshProUGUI>().text != "";i++)
        {
            b = btns[i];

        }
        //Vérifie si on est sortie de la boucle en ayant trouvé un bouton avc texte vide
        if (b.GetComponentInChildren<TextMeshProUGUI>().text == "")
        {
            //texte du bouton réponse trouvé = texte du bouton clavier cliqué
            b.GetComponentInChildren<TextMeshProUGUI>().text = transform.GetComponentInChildren<TextMeshProUGUI>().text;
            gameObject.SetActive(false); // on le met inactif
            obj_disable.Add(transform.GetInstanceID(), gameObject); //on l'ajoute au tableau des btns désac
            b.GetComponent<ReponseLettre>().Id = transform.GetInstanceID();
            //Technique de pro :
            //Le préfab des boutons de réponse contiennent une classe "Reponse lettre" avec comme seul ligne un 
            //attribut Id. On stock l'ID de notre bouton clavier cliqué, dans l'Id du bouton réponse.
            //Pour avoir des Clés uniques pour la map
        }

    }
    public void AnswerEvent()
    {
        GameObject retour;
        TextMeshProUGUI textMesh = transform.GetComponentInChildren<TextMeshProUGUI>();
        int id = transform.GetComponent<ReponseLettre>().Id; //On choppe l'Id du bouton qu'on a désac
        if (obj_disable.TryGetValue(id, out retour)) //on trouve du coup son GameObject grâce à la map
            obj_disable.Remove(id); //On le remove de la map (si on l'a trouvé)
        textMesh.text = "";
        retour.SetActive(true); // On le réactive
    }
}
