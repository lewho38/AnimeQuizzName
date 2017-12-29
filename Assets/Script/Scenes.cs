using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Scenes
{
    static int id = 0;
    public static int Id { get { return id; } set { id = value; } }
    static string anime, nom = "";
    public static string Anime { get { return anime; } set { anime = value; } }
    public static string Nom { get { return nom; } set { nom = value; } }

    public static void Load(string sceneName, int id, string anime, string nom)
    {
        Scenes.id = id;
        Scenes.anime = anime;
        Scenes.nom = nom;
        SceneManager.LoadScene(sceneName);
    }

}
