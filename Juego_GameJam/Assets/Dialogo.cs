using System.Collections;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    private bool Rangojugador;

    [SerializeField] private GameObject MarcadeDialogo;
   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bavi"))
        {
            Rangojugador = true;
            MarcadeDialogo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bavi"))
        {
            Rangojugador = false;
            MarcadeDialogo.SetActive(false);
        }
    }

}
