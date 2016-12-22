using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private float _maxValue;
    private float _minValue;
    private float _currentValue;
    private bool _initialised;
    private float _size;
    private RectTransform _rectTransformBar;
    
    void Awake()
    {
        _size = GetComponent<RectTransform>().rect.size.x;
        _rectTransformBar = transform.FindChild("Bar").GetComponent<RectTransform>();
    }

    void Start()
    {
        _initialised = false;
    }

    /// <summary>
    /// Permet de définir toutes les propriétés de la progresse bar
    /// </summary>
    /// <param name="maxValue">Valeur Max</param>
    /// <param name="minValue">Valeur Min</param>
    /// <param name="currentValue">Valeur actuel</param>
    public void SetValues(float maxValue, float minValue, float currentValue)
    {
        _maxValue = maxValue;
        _minValue = minValue;
        _initialised = true;
        ChangeValue(currentValue);
    }

    /// <summary>
    /// Permet de changer la valeur et d'ajuster le visuel
    /// </summary>
    /// <param name="newValue">Nouvelle valeur</param>
    public void ChangeValue(float newValue)
    {
        if (_initialised)
        {
            float newSize;

            //Controle des limites
            if (newValue < _minValue)
            {
                _currentValue = _minValue;
            }
            else if (newValue > _maxValue)
            {
                _currentValue = _maxValue;
            }
            else
            {
                _currentValue = newValue;
            }

            newSize = _size * (_currentValue / _maxValue);

            _rectTransformBar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, newSize);
        }
        else
        {
            Debug.LogError("");
        }
    }
}
