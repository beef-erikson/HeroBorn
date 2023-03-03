using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Destroyable<T> : MonoBehaviour where T : MonoBehaviour
{
    public float onscreenDelay = 3f;

    private void Start()
    {
        Destroy(this.gameObject, onscreenDelay);
    }
}
