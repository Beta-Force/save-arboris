using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoDeVida : MonoBehaviour
{
    [SerializeField] private float tiempoDeVida = 0.5f;

    void Start()
    {
        // Programar la destrucci�n despu�s de un tiempo espec�fico
        Destroy(gameObject, tiempoDeVida);
    }
}
