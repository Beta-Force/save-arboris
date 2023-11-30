using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Puerta : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public string nuevaEscena;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.PuntosTotales>0)
        {
            SceneManager.LoadScene(nuevaEscena);
        }
    }
}
