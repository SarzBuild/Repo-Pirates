using System.Collections.Generic;
using UnityEngine;

public class LerpBetweenTwoPoints : MonoBehaviour
{
    public readonly List<Transform> Transforms = new List<Transform>();
    private List<Vector3> _positionList;

    private int _lastPos;
    private int _moveTowardsNextPos;
    
    public float TimePerSegments = 10f;
    public float TimeIntoSegment = 5f;

    private void Start()
    {
        MakeVector3List();
    }

    private void MakeVector3List()
    {
        _positionList = new List<Vector3>();
        foreach (var t in Transforms)
        {
            _positionList.Add(t.position);
        }
        _lastPos = 0;
        _moveTowardsNextPos = 1;
    }

    private void Update()
    {
        if(_positionList != null && _positionList.Count > 1)
            ChangeNextMovePos();
    }

    private void ChangeNextMovePos()
    {
        TimeIntoSegment += Time.deltaTime;
        if (TimeIntoSegment > TimePerSegments)
        {
            _lastPos = _moveTowardsNextPos;
            _moveTowardsNextPos++;
            if (_moveTowardsNextPos == _positionList.Count)
            {
                _moveTowardsNextPos = 0;
            }
            TimeIntoSegment -= TimePerSegments;
        }
        var param = TimeIntoSegment / TimePerSegments;
        transform.position = Vector3.Lerp(_positionList[_lastPos], _positionList[_moveTowardsNextPos], param);
    }
}
