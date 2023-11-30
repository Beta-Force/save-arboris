using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private float moveSpeed = 5f;

    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalizamos el vector de movimiento para evitar movimientos diagonales más rápidos
        movement.Normalize();

        // Actualizamos la animación de movimiento
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Rotamos el jugador para que se oriente hacia la dirección del movimiento
        if (movement != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
        }

        // Comprobamos si el jugador está atacando o bloqueando
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("Block", true);
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            animator.SetBool("Block", false);
        }
    }

    void FixedUpdate()
    {
        // Movemos el jugador usando el Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
