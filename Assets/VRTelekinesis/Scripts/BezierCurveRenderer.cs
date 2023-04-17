using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PositionList : UnityEvent<List<Vector3>>
{

}
public class BezierCurveRenderer : MonoBehaviour
{
    public Transform _point1;
    public Transform _point2;
    public Transform _point3;
    public LineRenderer _line;
    public int _vertexCount = 12;
    public PositionList _sendPositions;
    void Start()
    {
        Detached();
    }

    void Update()
    {
    }


    public void Attached(Transform t)
    {
        _point3 = t;
        _line.useWorldSpace = true;
        if (_point3 != null)
        {

            var pointList = new List<Vector3>();

            for (float ratio = 0f / _vertexCount; ratio < 1; ratio += 1.0f / _vertexCount)
            {
                var tangentLineVertex1 = Vector3.Lerp(_point1.position, _point2.position, ratio);
                var tangentLineVertex2 = Vector3.Lerp(_point2.position, _point3.position, ratio);
                var bezierPoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
                pointList.Add(bezierPoint);
            }

            _line.positionCount = pointList.Count;
            _line.SetPositions(pointList.ToArray());
            _sendPositions.Invoke(pointList);
        }
    }

    public void Detached(){

        _line.positionCount = 2;
        _line.useWorldSpace = false;
        _line.SetPosition(0, new Vector3(0,0,0));
        _line.SetPosition(1, new Vector3(0,0,1));

    }

}
