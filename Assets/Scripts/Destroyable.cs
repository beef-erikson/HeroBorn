/********************************
 * Destroyable.cs
 * Generic class that will destroy the GameObject in 3 second by default.
 * Last Edit: 3-3-23
 * Troy Martin
 * 
 ********************************/

using UnityEngine;

public class Destroyable<T> : MonoBehaviour where T : MonoBehaviour
{
    public float onscreenDelay = 3f;

    private void Start()
    {
        Destroy(this.gameObject, onscreenDelay);
    }
}
