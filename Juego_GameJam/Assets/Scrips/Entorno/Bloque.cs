using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    [SerializeField] Transform vista;
    [SerializeField] LayerMask MascaraPiedra;
    [SerializeField] float distance;

    Transform piedra;
    
    public void Update()
    {
        Debug.DrawRay(transform.position, (vista.position - transform.position).normalized*distance);
        if(Input.GetKey(KeyCode.E))
        {
            RaycastHit2D Hit = Physics2D.Raycast(transform.position, vista.position - transform.position,distance,MascaraPiedra);
            Debug.Log(Hit == null);

            if (Hit.transform != null && piedra == null && Hit.transform.CompareTag("Piedra"))
            {
                piedra = Hit.transform;
                piedra.parent = transform;

            }
        }
        else if(Input.GetKeyUp(KeyCode.E) && piedra!=null)
        {
            piedra.parent=null;
            piedra = null;
        }
        
    }

}