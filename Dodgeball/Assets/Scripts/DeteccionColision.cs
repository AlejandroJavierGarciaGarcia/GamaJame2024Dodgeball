using UnityEngine;

public class DeteccionColision : MonoBehaviour
{
    public string etiquetaObjeto = "Dado"; // Cambia a la etiqueta de tu objeto

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(etiquetaObjeto))
        {
            Debug.Log("El jugador está tocando el objeto.");
            // Realiza aquí la acción que deseas cuando el jugador está tocando el objeto.
            DestruirObjeto(other.gameObject);
        }
    }

    void DestruirObjeto(GameObject objeto)
    {
        // Destruir el objeto
        Destroy(objeto);
    }
}
