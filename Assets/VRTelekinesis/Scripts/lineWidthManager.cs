using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineWidthManager : MonoBehaviour
{

    private float _width;
    private float _defaultWidth;
    private LineRenderer _thisLine;
    public float _speed;
    private bool _activated;

    void Start()
    {
        _thisLine = GetComponent<LineRenderer>();
        _defaultWidth = _thisLine.widthMultiplier;
        _width = _defaultWidth;
    }
    
    void Update()
    {
        _thisLine.widthMultiplier = _width;
        float t = _speed * Time.deltaTime;
        if (_activated)
        {
            _width = Mathf.MoveTowards(_width, 0, t);
        }
        else
        {
            _width = Mathf.MoveTowards(_width, _defaultWidth, t);

        }
    }

    public void Active(bool b)
    {
        _activated = b;
    }
}
