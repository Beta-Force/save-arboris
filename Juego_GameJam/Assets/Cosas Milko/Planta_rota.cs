using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planta_rota : MonoBehaviour
{
    [SerializeField] private GameObject Plantarota;


    public void Destruir()
    {
        Instantiate(Plantarota, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
