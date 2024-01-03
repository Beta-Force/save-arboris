using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    private Rigidbody2D rbd2D;
    [SerializeField] private float VelocidadDeMovimiento;

    [SerializeField] private float Distancia;

    [SerializeField] private LayerMask QueEsSuelo;


    private void Start()
    {
        rbd2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rbd2D.velocity = new Vector2(VelocidadDeMovimiento * transform.right.x, rbd2D.velocity.y);

        RaycastHit2D InformacionDelSuelo = Physics2D.Raycast(transform.position, transform.right, Distancia, QueEsSuelo);


        if (InformacionDelSuelo)
        {
            Girar();

        }
    }

    private void Girar()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PerderVida();
        }
    }
}