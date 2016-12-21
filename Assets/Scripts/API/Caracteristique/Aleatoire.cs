using UnityEngine;
using System.Collections;

public class Aleatoire
{
    private float _min, _max;

    public Aleatoire(float pMin, float pMax)
    {
        _min = pMin;
        _max = pMax;
    }

    public int LanceInt()
    {
        return Random.Range((int)_min, (int)_max);
    }

    public float LanceFloat()
    {
        return Random.Range(_min, _max);
    }
}

