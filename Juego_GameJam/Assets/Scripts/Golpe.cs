using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{
    public GameObject golpeado;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Basura")|| other.CompareTag("Enemigo"))
        {
            golpeado = other.gameObject;
            Destroy(golpeado);
            golpeado = GameObject.Find("Vacio");
        }
    }
}
