using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemy_Patrullaje : MonoBehaviour
{
    [SerializeField] private float velocidadmovimiento;

    [SerializeField] private Transform[] puntosDeMovimientos;

    [SerializeField] private float DistanciaMinima;

    private int NumeroAleatorio;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        NumeroAleatorio = Random.Range(0, puntosDeMovimientos.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        girar();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosDeMovimientos[NumeroAleatorio].position, velocidadmovimiento * Time.deltaTime);
        if (Vector2.Distance(transform.position, puntosDeMovimientos[NumeroAleatorio].position) < DistanciaMinima)
        {
            NumeroAleatorio = Random.Range(0, puntosDeMovimientos.Length);
            girar();
        }
    }


    private void girar()
    {
        if (transform.position.x < puntosDeMovimientos[NumeroAleatorio].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

}
