using UnityEngine;
using System.Collections;

public class JobBuilder
{
    private string _nom;

    private int _str;
    private int _int;
    private int _agi;
    private int _cha;
    private int _cc;
    private int _ct;
    private int _spd;
    private int _resiP;
    private int _resiM;

    private int _pa;
    private int _hp;
    private int _mana;

    /// <summary>
    /// Instancie le builder et met par défaut toutes les valeurs à 0
    /// </summary>
    public JobBuilder(string pNom)
    {
        _nom = pNom;

        _str = 0;
        _int = 0;
        _agi = 0;
        _cha = 0;
        _cc = 0;
        _ct = 0;
        _spd = 0;
        _resiP = 0;
        _resiM = 0;

        _hp = 0;
        _mana = 0;
        _pa = 0;
    }

    #region Get
    public string Nom
    {
        get { return _nom; }
    }
    #endregion

    #region Set
    public int SetCostStr
    {
        set { _str = value; }
    }
    public int SetCostInt
    {
        set { _int = value; }
    }
    public int SetCostAgi
    {
        set { _agi = value; }
    }
    public int SetCostCha
    {
        set { _cha = value; }
    }
    public int SetCostCc
    {
        set { _cc = value; }
    }
    public int SetCostCt
    {
        set { _ct = value; }
    }
    public int SetCostVit
    {
        set { _spd = value; }
    }
    public int SetCostResiP
    {
        set { _resiP = value; }
    }
    public int SetCostResiM
    {
        set { _resiM = value; }
    }
    public int SetCostPa
    {
        set { _pa = value; }
    }
    public int SetCostPv
    {
        set { _hp = value; }
    }
    public int SetCostMana
    {
        set { _mana = value; }
    }
    #endregion

    /// <summary>
    /// Retourne les valeurs dans l'ordre suivant : Agi, Cc ,Cha, Ct, Force, Intel, Mana, Pa, Pv, ResiM, ResiP, Vit
    /// </summary>
    /// <returns></returns>
    public int[] GetValues()
    {
        int[] r = new int[12];

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
