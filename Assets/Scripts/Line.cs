using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
   // [SerializeField] private AnimationCurve _animationCurve;

    // Start is called before the first frame update
    private void Start()
    {
        makeLine();
        //makeLine2();
    }

    public void makeLine()
    {
        var lineRenderer = gameObject.AddComponent<LineRenderer>();
        var positions = new Vector3[]{
        new Vector3(0, 0, 0),               // ŠJŽn“_
        new Vector3(8, 0, 0),
        new Vector3(3, 10, 0),
        };

        // lineRenderer.widthCurve = _animationCurve;

        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;

        lineRenderer.positionCount = positions.Length;
        lineRenderer.loop = true;

        lineRenderer.SetPositions(positions);

    }

}
