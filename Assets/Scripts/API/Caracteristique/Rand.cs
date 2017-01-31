using UnityEngine;

public class Rand
{
    private float _min, _max;

    public Rand(float pMin, float pMax)
    {
        _min = pMin;
        _max = pMax;
    }

    public Rand(Rand aleat)
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

