using UnityEngine;

public class DeteccionColision : MonoBehaviour
{
    public string etiquetaObjeto = "Dado"; // Cambia a la etiqueta de tu objeto

    public delegate void AbilityFunctions(GameObject objeto);
    private AbilityFunctions[] abilityArray;
    
    public AudioClip speedUpSound; // Assign the sound clip in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Initialize the array with the functions you want
        abilityArray = new AbilityFunctions[]
        {
            speedUpAbility
            // Add more functions as needed
        };
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(etiquetaObjeto))
        {
            Debug.Log("El jugador está tocando el objeto.");
            // Realiza aquí la acción que deseas cuando el jugador está tocando el objeto.
            DestruirObjeto(other.gameObject);
            int randomIndex = Random.Range(0, abilityArray.Length);
            abilityArray[randomIndex]?.Invoke(other.gameObject);
            
        }
    }

    void DestruirObjeto(GameObject objeto)
    {
        // Destruir el objeto
        Destroy(objeto);
    }

    void speedUpAbility(GameObject objeto){
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Speedup nashee for GameObject: ");
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.SpeedUp(20f);
            audioSource.PlayOneShot(speedUpSound);
        }
    }
}
