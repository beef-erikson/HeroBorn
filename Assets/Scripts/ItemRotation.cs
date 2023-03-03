/********************************
 * ItemRotation.cs
 * Adds continuous rotation to the attached object.
 * Last Edit: 3-3-23
 * Troy Martin
 *
 ********************************/

using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public int rotationSpeed;
    private Transform _item;

    // Start is called before the first frame update
    private void Start()
    {
        _item = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        _item.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }
}
