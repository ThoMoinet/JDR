using UnityEngine;

public class Aleatoire
{
    private float _min, _max;

    public Aleatoire(float pMin, float pMax)
    {
        _min = pMin;
        _max = pMax;
    }

    public Aleatoire(Aleatoire aleat)
    {
        _min = aleat._min;
        _max = aleat._max;
    }

    public float Generate(bool round)
    {
        float r = Random.Range(_min, _max);

        if (round)
        {
            r = Mathf.Round(r);
        }

        return r;
    }
}

