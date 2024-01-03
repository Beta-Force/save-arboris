using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoDeVida : MonoBehaviour
{
    [SerializeField] private float tiempoDeVida = 0.5f;

    void Start()
    {
        // Programar la destrucción después de un tiempo específico
        Destroy(gameObject, tiempoDeVida);
    }
}
