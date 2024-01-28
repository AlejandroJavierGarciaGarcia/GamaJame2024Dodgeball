using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreLayerCollision : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 7);
        Physics.IgnoreLayerCollision(1, 8);
        //Collision between two layers is ignored
        //In this example, Layer 6 & 7 are ignoring each other
    }
}