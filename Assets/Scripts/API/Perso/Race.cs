using UnityEngine;
using System.Collections;

public class Race
{
    public string Nom;

    public Aleatoire Force;
    public Aleatoire Intel;
    public Aleatoire Agi;
    public Aleatoire Charisme;
    public Aleatoire Cc;
    public Aleatoire Ct;
    public Aleatoire Pa;
    public Aleatoire Vitesse;
    public Aleatoire ResiP;
    public Aleatoire ResiM;
    public Aleatoire Pv;
    public Aleatoire Mana;

    public Race(string pNom, Aleatoire pForce, Aleatoire pIntel, Aleatoire pAgi, Aleatoire pCharisme, Aleatoire pCc, Aleatoire pCt,
        Aleatoire pPa, Aleatoire pVitesse, Aleatoire pResiP, Aleatoire pResiM, Aleatoire pPv, Aleatoire pMana)
    {
        Nom = pNom;
        Force = pForce;
        Intel = pIntel;
        Agi = pAgi;
        Charisme = pCharisme;
        Cc = pCc;
        Ct = pCt;
        Pa = pPa;
        Vitesse = pVitesse;
        ResiP = pResiP;
        ResiM = pResiM;
        Pv = pPv;
        Mana = pMana;
    }

    public Race(Race pRace)
    {
        Nom = pRace.Nom;
        Force = pRace.Force;
        Intel = pRace.Intel;
        Agi = pRace.Agi;
        Charisme = pRace.Charisme;
        Cc = pRace.Cc;
        Ct = pRace.Ct;
        Pa = pRace.Pa;
        Vitesse = pRace.Vitesse;
        ResiP = pRace.ResiP;
        ResiM = pRace.ResiM;
        Pv = pRace.Pv;
        Mana = pRace.Mana;
    }
    
    public void ApplicationCarac(PersonnageScript pPerso)
    {
        pPerso.Force = new Carac(Force.LanceFloat());
        pPerso.Intel = new Carac(Intel.LanceFloat());
        pPerso.Agi = new Carac(Agi.LanceFloat());
        pPerso.Charisme = new Carac(Charisme.LanceFloat());
        pPerso.Cc = new Carac(Cc.LanceFloat());
        pPerso.Ct = new Carac(Ct.LanceFloat());
        pPerso.Pa = new Carac(Pa.LanceFloat());
        pPerso.Vitesse = new Carac(Vitesse.LanceFloat());
        pPerso.ResiP = new Carac(ResiP.LanceFloat());
        pPerso.ResiM = new Carac(ResiM.LanceFloat());

        pPerso.Pv = new CaracConso(Pv.LanceFloat());
        pPerso.Mana = new CaracConso(Mana.LanceFloat());
    }
}
