using UnityEngine;
using System.Collections;

public class Characteristic
{
    public float Valeur { get; set; }
    private float _valeurDefaut;

    public Characteristic(float pValeur)
    {
        Valeur = pValeur;
        _valeurDefaut = pValeur;
    }

    public Characteristic(Characteristic pCarac)
    {
        Valeur = pCarac.Valeur;
        _valeurDefaut = pCarac._valeurDefaut;
    }

    /// <summary>
    /// Restauration de la valeur usuelle par la valeur de sauvegarde
    /// </summary>
    public virtual void Reinitialisation()
    {
        Valeur = _valeurDefaut;
    }

    /// <summary>
    /// Change la valeur usuelle mais également la valeur utilisée pour la réinitialisation
    /// </summary>
    /// <param name="value"></param>
    public virtual void ValueChange(float value)
    {
        _valeurDefaut = value;
        Valeur = value;
    }
}
