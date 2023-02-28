using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public int rotationSpeed;
    private Transform _itemTF;

    // Start is called before the first frame update
    void Start()
    {
        _itemTF = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _itemTF.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }
}
