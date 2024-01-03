using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tomarcosas : MonoBehaviour
{
    public bool Tomable = false;
    public Movimiento BaviM;
    public Piedra piedrita;
    public bool acercar = true;

    
    public GameObject sujetable;

    Renderer rendererSujetable;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Piedra") || other.CompareTag("Maceta"))
        {
            if (BaviM.Tomando == false)
            {
                Tomable = true;
                sujetable = other.gameObject;
                rendererSujetable = sujetable.GetComponent<Renderer>();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Piedra") || other.CompareTag("Maceta"))
        {
            StartCoroutine(TriggerTime());
        }
    }

    private void Update()
    {
        Collider2D colliderSujetable = sujetable.GetComponent<Collider2D>();

        

        if (BaviM.Agarrar)
        {
            sujetable.transform.position = transform.position;
            sujetable.transform.position = sujetable.transform.position + Vector3.up * 0.2f;


            if (acercar)
            {    
                if (rendererSujetable != null)
                {
                    rendererSujetable.sortingOrder = 6;
                }
            }
            else
            {
                rendererSujetable.sortingOrder = 4;
            }

            BaviM.Tomando = true;

            if (colliderSujetable != null)
            {
                colliderSujetable.enabled = false;
            }
        }
        else
        {
            BaviM.Tomando = false;
            if (colliderSujetable != null)
            {
                colliderSujetable.enabled = true;
                rendererSujetable.sortingOrder = 4;
            }
        }
    }

    IEnumerator TriggerTime()
    {
        yield return new WaitForSeconds(0.1f);
        if (Tomable)
        {
            Tomable = false;
            Debug.Log("Intomable");
        }
    }
}
