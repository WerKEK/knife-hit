using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, -5);
    }
}
