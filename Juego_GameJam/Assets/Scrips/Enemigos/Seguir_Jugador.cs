using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir_Jugador : MonoBehaviour
{
    [SerializeField] public Transform Jugador;
    [SerializeField] float velocidad;
    [SerializeField] private float Distancia;
    private Rigidbody2D Enemigo;

    public Vector3 PuntoInicial;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        PuntoInicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Enemigo= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 Posicion = transform.position;
        Vector2 mono = Jugador.position;
        float longitud = (Posicion - mono).sqrMagnitude;
        animator.SetFloat("Idle", Distancia);
            //Debug.Log(transform.name+ " "+longitud);
        if(longitud<(Distancia*Distancia) )
        {
            Vector2 direccion = (Jugador.position - transform.position).normalized;
            Enemigo.velocity = direccion*velocidad*Time.deltaTime;
        }
        else
        {
            Enemigo.velocity = Vector2.zero;
        }

    }

    public void girar(Vector3 objetivo)
    {
        if (transform.position.x < objetivo.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Distancia);
    }

}
