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
    private Vector2 animMoveInput;

    private void OnEnable()
    {
        inputReader.MoveEvent += OnMove;
        inputReader.MoveEventPerformed += OnMovePerformed;
    }

    private void OnDisable()
    {
        inputReader.MoveEvent -= OnMove;
        inputReader.MoveEventPerformed -= OnMovePerformed;
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("Speed", moveInput.magnitude);
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(moveInput.x * speed * 50f, moveInput.y * speed * 50f) * Time.fixedDeltaTime;
    }

    void OnMove(Vector2 _moveVec)
    {
        moveInput = _moveVec;
        print(_moveVec);
    }

    void OnMovePerformed(Vector2 _moveDir)
    {
        animator.SetFloat("Horizontal", _moveDir.x);
        animator.SetFloat("Vertical", _moveDir.y);
    }
}

