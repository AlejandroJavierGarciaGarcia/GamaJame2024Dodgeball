using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceProgram : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidadRotacion = 30.0f;
    private bool _initialized = false;
        void Start()
    {
        _initialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(_initialized){
            transform.Rotate(new Vector3(1, 1, 0) * velocidadRotacion * Time.deltaTime);
        }
    }
}
