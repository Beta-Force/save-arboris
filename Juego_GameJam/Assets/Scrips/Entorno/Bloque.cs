using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    [SerializeField] Transform vista;
    [SerializeField] LayerMask MascaraPiedra;
    [SerializeField] float distance;

    [Header("Input")]
    [SerializeField] private InputReader inputReader;

    Transform piedra;

    #region Subscribing To Events
    private void OnEnable()
    {
        inputReader.GrapStartedEvent += OnGrapStarted;
        inputReader.GrapCanceledEvent += OnGrabCanceled;
    }

    private void OnDisable()
    {
        inputReader.GrapStartedEvent -= OnGrapStarted;
        inputReader.GrapCanceledEvent -= OnGrabCanceled;
    }
    #endregion

    void OnGrapStarted()
    {
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, vista.position - transform.position, distance, MascaraPiedra);
        //Debug.Log(Hit == null);

        if (Hit.transform != null && piedra == null && Hit.transform.CompareTag("Piedra"))
        {
            piedra = Hit.transform;
            piedra.parent = transform;
        }
    }

    void OnGrabCanceled()
    {
        if(piedra != null)
        {
            piedra.parent = null;
            piedra = null;
        }
    }
}