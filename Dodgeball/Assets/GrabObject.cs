using UnityEngine;

public class GrabObject : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    public float pickUpDistance = 10f;
    private GameObject objetoAgarrado; // Almacena la referencia al objeto agarrado

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && objetoAgarrado == null)
        {
            TryGrabObject();
        }else if(Input.GetKeyDown(KeyCode.E) && objetoAgarrado != null){
            ReleaseObject();
        }
        // Si el objeto está agarrado, actualiza su posición al jugador
        if (objetoAgarrado != null)
        {
            objetoAgarrado.transform.position = new Vector3(transform.position.x + 0.2f,transform.position.y+0.2f, transform.position.z+0.2f); // Pega el objeto al jugador
        }
    }


    public bool IsObjectGrabbed()
    {
        return objetoAgarrado != null;
    }

    public GameObject GetObjetoAgarrado()
    {
        return objetoAgarrado != null ? objetoAgarrado.gameObject : null;
    }

    

    void TryGrabObject()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit rayHit, pickUpDistance))
        {
            Debug.Log(rayHit.transform);
            if (rayHit.collider.CompareTag("Objeto"))
            {
                // Agarra el objeto y lo pega al jugador
                GrabObjectAndAttach(rayHit.collider.gameObject);
            }
        }
    }
    
    public void ReleaseObject()
    {
        // Desvincula el objeto del jugador
        objetoAgarrado.transform.SetParent(null);

        // Reactiva la gravedad o cualquier otro comportamiento físico si es necesario
        Rigidbody objetoRigidbody = objetoAgarrado.GetComponent<Rigidbody>();
        if (objetoRigidbody != null)
        {
            objetoRigidbody.isKinematic = false;
        }

        // Resetea la referencia al objeto agarrado
        objetoAgarrado = null;
    }
    void GrabObjectAndAttach(GameObject objeto)
    {
        // Establece el objeto como hijo del jugador
        objeto.transform.SetParent(transform);

        // Almacena la referencia al objeto agarrado
        objetoAgarrado = objeto;

        // Modifica la posición del objeto agarrado si es necesario
       

        // Desactiva la gravedad o cualquier otro comportamiento físico si es necesario
        Rigidbody objetoRigidbody = objeto.GetComponent<Rigidbody>();
        if (objetoRigidbody != null)
        {
            objetoRigidbody.isKinematic = true;
        }
    }
}
