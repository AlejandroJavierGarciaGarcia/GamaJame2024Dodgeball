using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dice;
    private Vector3 center = new Vector3(-13.0273438f,4.94875002f,4.11642742f);
    private float xBoundary = 3f;
    private float zBoundary = 5f;
    public float tiempoDeEspera = 2.0f;

    void Start()
    {
        InvokeRepeating("GenerarDado", 0.0f, tiempoDeEspera);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerarDado()
    {
        // Genera el objeto prefab en la posición actual del GeneradorDeObjetos
        Instantiate(dice, new Vector3(Random.Range(center.x - xBoundary, center.x + xBoundary),5.4f,Random.Range(center.z - zBoundary, center.z + zBoundary)), Quaternion.identity);
    }
}
