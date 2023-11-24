using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    [SerializeField] private float Radio;

    [SerializeField] private float FuerzaExplosion;

    [SerializeField] private GameObject EfectoExplosion;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explosion();
        }
    }
    public void Explosion()
    {
        Instantiate(EfectoExplosion, transform.position, Quaternion.identity);

        Collider2D[] ObjetosIniciales = Physics2D.OverlapCircleAll(transform.position, Radio);

        foreach(Collider2D colisionador in ObjetosIniciales)
        {
            Planta_rota planta_Rota = colisionador.GetComponent<Planta_rota>();
            if (planta_Rota !=null)
            {
                planta_Rota.Destruir();
            }
        }

        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, Radio);

        foreach (Collider2D colisionador in objetos)
        {
            Rigidbody2D rb2D = colisionador.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 direccion = colisionador.transform.position - transform.position;
                float distancia = 1 + direccion.magnitude;
                float FuerzaFinal = FuerzaExplosion / distancia;
                rb2D.AddForce(direccion * FuerzaFinal);

            }
        }
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radio);
    }
}
