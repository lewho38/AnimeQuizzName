using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField]
    private int id = 0;
    public int Id { get { return id; } set { id = value; } }
    [SerializeField]
    private string anime = "undefined";
    public string Anime { get { return anime; } set { anime = value; } }
    [SerializeField]
    private string nom = "undefined";
    public string Nom { get { return nom; } set { nom = value; } }
    /*public int id = 0;
    public string anime, nom = "undefined";*/
    // Use this for initialization
    public void LoadGameScene()
    {
        Scenes.Load("COIN", id, anime,nom);
    }
}
