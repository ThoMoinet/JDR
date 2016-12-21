using UnityEngine;
using System.Collections;

public class Carac
{
    public float Valeur { get; set; }
    private float _valeurDefaut;

    public Carac(float pValeur)
    {
        Valeur = pValeur;
        _valeurDefaut = pValeur;
    }

    public Carac(Carac pCarac)
    {
        Valeur = pCarac.Valeur;
        _valeurDefaut = pCarac._valeurDefaut;
    }

    public virtual void Reinitialisation()
    {
        Valeur = _valeurDefaut;
    }

}
