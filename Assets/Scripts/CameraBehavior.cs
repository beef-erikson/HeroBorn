/********************************
 * CameraBehavior.cs
 * Manages camera position - 3rd person
 * Last Edit: 3-3-23
 * Troy Martin
 * 
 ********************************/

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
