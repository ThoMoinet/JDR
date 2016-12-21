using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float MaxValue;
    public float MinValue;

    private float _currentValue;
    private float _size;
    private RectTransform _rectTransformBar;

    void Awake()
    {
        _size = GetComponent<RectTransform>().rect.size.x;
        _rectTransformBar = transform.FindChild("Bar").GetComponent<RectTransform>();
    }

    //// Use this for initialization
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    /// <summary>
    /// Permet de changer la valeur et d'ajuster le visuel
    /// </summary>
    /// <param name="newValue">Nouvelle valeur</param>
    public void ChangeValue(float newValue)
    {
        float newSize;

        if (newValue < MinValue)
        {
            _currentValue = MinValue;
        }
        else if (newValue > MaxValue)
        {
            _currentValue = MaxValue;
        }
        else
        {
            _currentValue = newValue;
        }

        newSize = _size * (_currentValue / MaxValue);

        _rectTransformBar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, newSize);
    }
}
