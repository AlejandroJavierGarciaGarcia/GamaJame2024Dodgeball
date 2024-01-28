using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vh1 : MonoBehaviour
{
    public Transform target;
    public float speed;
    private bool isWaiting = true;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndMove());
    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(5f);
        isWaiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                // Llegó al objetivo, reinicia la posición
                transform.position = new Vector3(-12.5f,4.99f,-70f); // Puedes ajustar esto según tu necesidad
                isWaiting = true;
                StartCoroutine(WaitAndMove());
            }
        }
    }
}
