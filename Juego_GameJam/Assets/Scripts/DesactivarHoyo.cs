using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarHoyo : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si el objeto con el que colisionamos tiene el tag "Piedra"
        if (collision.collider.CompareTag("Piedra"))
        {
            // Desactivar colisiones del objeto actual
            GetComponent<Collider2D>().enabled = false;
            animator.SetBool("Tapado", true);
        }
    }
}
