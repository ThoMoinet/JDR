using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character
{
    public string Nom;
    public EGenre Genre;
    public int Age;
    public int Lvl;
    public decimal Argent;

    public Race Espece;
    public Classe Metier;

    public Carac Force;
    public Carac Intel;
    public Carac Agi;
    public Carac Cha;
    public Carac Cc;
    public Carac Ct;
    public Carac Vit;
    public Carac ResiP;
    public Carac ResiM;

    public CaracConso Pv;
    public CaracConso Mana;
    public CaracConso Xp;
    public CaracConso Pa;

    public List<Item> Inventaire;
    public List<Competence> Competences;
    public List<Character> Familiers;

    public string ImageEmplacement;

    public Character()
    {

    }

    public Character(string pNom, EGenre pGenre, int pAge, Race pEspece, Classe pMetier, string pImageEmplacement)
    {
        Nom = pNom;
        Genre = pGenre;
        Age = pAge;
        Lvl = 1;
        Argent = 0;

        Espece = pEspece;
        Metier = pMetier;

        Xp = new CaracConso(0);

        Inventaire = new List<Item>();
        Competences = new List<Competence>();
        Familiers = new List<Character>();

        ImageEmplacement = pImageEmplacement;

        Espece.ApplicationCarac(this);
        Metier.ApplicationCarac(this);
    }

    public Character(Character pPersonnageScript)
    {
        Nom = pPersonnageScript.Nom;
        Genre = pPersonnageScript.Genre;
        Age = pPersonnageScript.Age;
        Lvl = pPersonnageScript.Lvl;
        Argent = pPersonnageScript.Argent;

        Espece = pPersonnageScript.Espece;
        Metier = pPersonnageScript.Metier;

        Xp = pPersonnageScript.Xp;

        Inventaire = pPersonnageScript.Inventaire;
        Competences = pPersonnageScript.Competences;
        Familiers = pPersonnageScript.Familiers;

        ImageEmplacement = pPersonnageScript.ImageEmplacement;

        Force = pPersonnageScript.Force;
        Intel = pPersonnageScript.Intel;
        Agi = pPersonnageScript.Agi;
        Cha = pPersonnageScript.Cha;
        Cc = pPersonnageScript.Cc;
        Ct = pPersonnageScript.Ct;
        Pa = pPersonnageScript.Pa;
        Vit = pPersonnageScript.Vit;
        ResiP = pPersonnageScript.ResiP;
        ResiM = pPersonnageScript.ResiM;

        Pv = pPersonnageScript.Pv;
        Mana = pPersonnageScript.Mana;
    }

    public enum EGenre
    {
        Homme, Femme, Autre
    }

}
