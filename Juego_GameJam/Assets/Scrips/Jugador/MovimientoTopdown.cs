using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTopdown : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    [Header("Input")]
    [SerializeField] private InputReader inputReader;

    private Rigidbody2D rb2D;
    private Animator animator;

    private Vector2 moveInput;

    private void OnEnable()
    {
        inputReader.MoveEvent += OnMove;
    }

    private void OnDisable()
    {
        inputReader.MoveEvent -= OnMove;
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        // Actualizar la animación de movimiento
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.magnitude);
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + moveInput * speed * Time.fixedDeltaTime);
    }

    void OnMove(Vector2 _moveVec)
    {

    }
}

