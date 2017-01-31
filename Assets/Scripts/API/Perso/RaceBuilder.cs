using UnityEngine;
using System.Collections;

public class RaceBuilder
{
    private string _nom;

    private Aleatoire _str;
    private Aleatoire _int;
    private Aleatoire _agi;
    private Aleatoire _cha;
    private Aleatoire _cc;
    private Aleatoire _ct;
    private Aleatoire _spd;
    private Aleatoire _resiP;
    private Aleatoire _resiM;

    private Aleatoire _pa;
    private Aleatoire _hp;
    private Aleatoire _mana;

    /// <summary>
    /// Instancie le builder et met par défaut toutes les valeurs à 0
    /// </summary>
    public RaceBuilder(string pNom)
    {
        _nom = pNom;

        _str = new Aleatoire(0, 0);
        _int = new Aleatoire(0, 0);
        _agi = new Aleatoire(0,0);
        _cha = new Aleatoire(0, 0);
        _cc = new Aleatoire(0, 0);
        _ct = new Aleatoire(0, 0);
        _spd = new Aleatoire(0, 0);
        _resiP = new Aleatoire(0, 0);
        _resiM = new Aleatoire(0, 0);

        _hp = new Aleatoire(0, 0);
        _mana = new Aleatoire(0, 0);
        _pa = new Aleatoire(0, 0);
    }

    #region Get
    public string Nom
    {
        get { return _nom; }
    }
    #endregion

    #region Set
    public Aleatoire SetStr
    {
        set { _str = value; }
    }
    public Aleatoire SetInt
    {
        set { _int = value; }
    }
    public Aleatoire SetAgi
    {
        set { _agi = value; }
    }
    public Aleatoire SetCha
    {
        set { _cha = value; }
    }
    public Aleatoire SetCc
    {
        set { _cc = value; }
    }
    public Aleatoire SetCt
    {
        set { _ct = value; }
    }
    public Aleatoire SetSpd
    {
        set { _spd = value; }
    }
    public Aleatoire SetResiP
    {
        set { _resiP = value; }
    }
    public Aleatoire SetResiM
    {
        set { _resiM = value; }
    }
    public Aleatoire SetPa
    {
        set { _pa = value; }
    }
    public Aleatoire SetHp
    {
        set { _hp = value; }
    }
    public Aleatoire SetMana
    {
        set { _mana = value; }
    }

    #endregion

    /// <summary>
    /// Retourne les valeurs sous forme d'un tableau
    /// </summary>
    /// <returns></returns>
    public Aleatoire[] GetValues()
    {
        Aleatoire[] r = new Aleatoire[12];

        r[(int)Character.ECarac.Agi] = _agi;
        r[(int)Character.ECarac.Cc] = _cc;
        r[(int)Character.ECarac.Cha] = _cha;
        r[(int)Character.ECarac.Ct] = _ct;
        r[(int)Character.ECarac.Str] = _str;
        r[(int)Character.ECarac.Int] = _int;
        r[(int)Character.ECarac.Mana] = _mana;
        r[(int)Character.ECarac.Pa] = _pa;
        r[(int)Character.ECarac.Hp] = _hp;
        r[(int)Character.ECarac.ResiM] = _resiM;
        r[(int)Character.ECarac.ResiP] = _resiP;
        r[(int)Character.ECarac.Spd] = _spd;

        return r;
    }
}
