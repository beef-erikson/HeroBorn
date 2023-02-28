using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);
    private Transform _targetTF;

    // Start is called before the first frame update
    private void Start()
    {
        _targetTF = GameObject.Find("Player").transform;
    }

    // LateUpdate is called after Update
    private void LateUpdate()
    {
        this.transform.position = _targetTF.TransformPoint(camOffset);
        this.transform.LookAt(_targetTF);
    }
}
