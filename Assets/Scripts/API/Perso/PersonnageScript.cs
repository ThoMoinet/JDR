using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonnageScript
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
    public Carac Charisme;
    public Carac Cc;
    public Carac Ct;
    public Carac Pa;
    public Carac Vitesse;
    public Carac ResiP;
    public Carac ResiM;

    public CaracConso Pv;
    public CaracConso Mana;
    public CaracConso Xp;

    public List<Item> Inventaire;
    public List<Competence> Competences;
    public List<PersonnageScript> Familiers;

    public string ImageEmplacement;

    public PersonnageScript()
    {

    }

    public PersonnageScript(string pNom, EGenre pGenre, int pAge, Race pEspece, Classe pMetier, string pImageEmplacement)
    {
        Nom = pNom;
        Genre = pGenre;
        Age = pAge;
        Lvl = 0;
        Argent = 0;

        Espece = pEspece;
        Metier = pMetier;

        Xp = new CaracConso(0);

        Inventaire = new List<Item>();
        Competences = new List<Competence>();
        Familiers = new List<PersonnageScript>();

        ImageEmplacement = pImageEmplacement;

        Espece.ApplicationCarac(this);
        Metier.ApplicationCarac(this);
    }

    public PersonnageScript(PersonnageScript pPersonnageScript)
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
        Charisme = pPersonnageScript.Charisme;
        Cc = pPersonnageScript.Cc;
        Ct = pPersonnageScript.Ct;
        Pa = pPersonnageScript.Pa;
        Vitesse = pPersonnageScript.Vitesse;
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
