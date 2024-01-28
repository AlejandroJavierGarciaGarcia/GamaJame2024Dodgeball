using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public float fuerzaExpulsion = 10f; // Ajusta la fuerza de expulsión según tus necesidades

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vehiculo"))
        {
            // Calcular la dirección de expulsión
            Vector3 direccionExpulsion = (collision.transform.position - transform.position).normalized;

            // Aplicar la fuerza para hacer que el jugador salga volando
            GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaExpulsion, ForceMode.Impulse);
            Debug.Log("COLISION CON VEHICULO");
        }
    }
}
