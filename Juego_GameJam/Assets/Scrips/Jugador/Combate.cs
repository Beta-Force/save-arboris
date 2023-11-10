using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;

    [Header("Input")]
    [SerializeField] private InputReader inputReader;
    private Animator animator;

    private void OnEnable()
    {
        inputReader.AttackEvent += OnAttack;
    }

    private void OnDisable()
    {
        inputReader.AttackEvent -= OnAttack;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Golpe();
            animator.SetTrigger("Atacar");
        }
    }

    private void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach ( Collider2D collisionador in objetos)
        {
            if (collisionador.CompareTag("Enemigo"))
            {
                collisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(controladorGolpe.position, radioGolpe);
    }

    private void Awake()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemigo"))
        {
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("Basura"))
        {
            Destroy(other.gameObject);
        }

    }

    void OnAttack()
    {

    }
}
