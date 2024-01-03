using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] private Transform ControladorDisparo;

    [SerializeField] private GameObject Bomba;


    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        Instantiate(Bomba, ControladorDisparo.position, ControladorDisparo.rotation);
    }
    



}
