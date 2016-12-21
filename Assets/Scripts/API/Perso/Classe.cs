using UnityEngine;
using System.Collections;

public class Classe
{
    public string Nom;

    public int ModifForce;
    public int ModifIntel;
    public int ModifAgi;
    public int ModifCharisme;
    public int ModifCc;
    public int ModifCt;
    public int ModifPa;
    public int ModifVitesse;
    public int ModifResiP;
    public int ModifResiM;
    public int ModifPv;
    public int ModifMana;

    /// <summary>
    /// Constructeur pour créer une Classe à partir de 0
    /// </summary>
    /// <param name="pNom">Nom</param>
    /// <param name="pModifForce">Modificateur de Force</param>
    /// <param name="pModifIntel">Modificateur d'Inteligence</param>
    /// <param name="pModifAgi">Modificateur d'Agilité</param>
    /// <param name="pModifCharisme">Modificateur de Charisme</param>
    /// <param name="pModifCc">Modificateur de Capacité de Combat</param>
    /// <param name="pModifCt">Modificateur de Capacité de Tir</param>
    /// <param name="pModifPa">Modificateur de Point d'Action</param>
    /// <param name="pModifVitesse">Modificateur de Vitesse</param>
    /// <param name="pModifResiP">Modificateur de Resistance Physique</param>
    /// <param name="pModifResiM">Modificateur de Resistance Magique</param>
    /// <param name="pModifPv">Modificateur de Point de Vie</param>
    /// <param name="pModifMana">Modificateur de Mana</param>
    public Classe(string pNom, int pModifForce, int pModifIntel, int pModifAgi, int pModifCharisme, int pModifCc, int pModifCt,
        int pModifPa, int pModifVitesse, int pModifResiP, int pModifResiM, int pModifPv, int pModifMana)
    {
        Nom = pNom;
        ModifForce = pModifForce;
        ModifIntel = pModifIntel;
        ModifAgi = pModifAgi;
        ModifCharisme = pModifCharisme;
        ModifCc = pModifCc;
        ModifCt = pModifCt;
        ModifPa = pModifPa;
        ModifVitesse = pModifVitesse;
        ModifResiP = pModifResiP;
        ModifResiM = pModifResiM;
        ModifPv = pModifPv;
        ModifMana = pModifMana;
    }

    /// <summary>
    /// Constructeur pour construire un classe à partir d'une autre (clone)
    /// </summary>
    /// <param name="pClasse"></param>
    public Classe(Classe pClasse)
    {
        Nom = pClasse.Nom;
        ModifForce = pClasse.ModifForce;
        ModifIntel = pClasse.ModifIntel;
        ModifAgi = pClasse.ModifAgi;
        ModifCharisme = pClasse.ModifCharisme;
        ModifCc = pClasse.ModifCc;
        ModifCt = pClasse.ModifCt;
        ModifPa = pClasse.ModifPa;
        ModifVitesse = pClasse.ModifVitesse;
        ModifResiP = pClasse.ModifResiP;
        ModifResiM = pClasse.ModifResiM;
        ModifPv = pClasse.ModifPv;
        ModifMana = pClasse.ModifMana;
    }

    /// <summary>
    /// Méthode utilisée pour la création d'un nouveau personnage. Elle applique les modifications de la classe au personnage
    /// </summary>
    /// <param name="pPerso">Personnage à modifier</param>
    public void ApplicationCarac(PersonnageScript pPerso)
    {
        pPerso.Force = new Carac(pPerso.Force.Valeur + ModifForce);
        pPerso.Intel = new Carac(pPerso.Intel.Valeur + ModifIntel);
        pPerso.Agi = new Carac(pPerso.Agi.Valeur + ModifAgi);
        pPerso.Charisme = new Carac(pPerso.Charisme.Valeur + ModifCharisme);
        pPerso.Cc = new Carac(pPerso.Cc.Valeur + ModifCc);
        pPerso.Ct = new Carac(pPerso.Ct.Valeur + ModifCt);
        pPerso.Pa = new Carac(pPerso.Pa.Valeur + ModifPa);
        pPerso.Vitesse = new Carac(pPerso.Vitesse.Valeur + ModifVitesse);
        pPerso.ResiP = new Carac(pPerso.ResiP.Valeur + ModifResiP);
        pPerso.ResiM = new Carac(pPerso.ResiM.Valeur + ModifResiM);

        pPerso.Pv = new CaracConso(pPerso.Pv.Valeur + ModifPv);
        pPerso.Mana = new CaracConso(pPerso.Mana.Valeur + ModifMana);
    }
}
