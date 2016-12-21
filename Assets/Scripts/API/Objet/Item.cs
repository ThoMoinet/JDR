using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public string Nom;
    public EGenre Genre;

    public Item (string pNom, EGenre pGenre)
    {
        Nom = pNom;
        Genre = pGenre;
    }

    #region Unity Function

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    public enum EGenre
    {
        Arme1M, Arme2M, Conso, Tete, Torse, Main, Jambe, Pied, Bijoux
    }
}
