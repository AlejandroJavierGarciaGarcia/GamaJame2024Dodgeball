using UnityEngine;

public class ThrowingTutorial : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;

    [Header("Settings")]
    public float throwForce;
    public float throwUpwardForce;
    public float throwCooldown = 1f;  // Agrega la variable de tiempo de espera para lanzar

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        // Verifica si hay un objeto agarrado antes de permitir lanzar
        if (GetComponent<GrabObject>().IsObjectGrabbed() && Input.GetKeyDown(KeyCode.Mouse0) && readyToThrow)
        {
            Throw();
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        // Obtén el objeto actualmente agarrado
        GameObject objetoAgarrado = GetComponent<GrabObject>().GetObjetoAgarrado();

        // Verifica que el objeto agarrado exista
        if (objetoAgarrado != null)
        {
            // Obtén el Rigidbody del objeto agarrado
            Rigidbody objetoRb = objetoAgarrado.GetComponent<Rigidbody>();

            // Desvincula el objeto del jugador
            GetComponent<GrabObject>().ReleaseObject();

            // Activa la gravedad o cualquier otro comportamiento físico
            if (objetoRb != null)
            {
                objetoRb.isKinematic = false;

                // Calcular la dirección y fuerza para lanzar el objeto
                Vector3 forceDirection = cam.transform.forward;
                Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

                // Añadir fuerza al objeto agarrado para lanzarlo
                objetoRb.AddForce(forceToAdd, ForceMode.Impulse);
            }
        }

        // Implementa throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
