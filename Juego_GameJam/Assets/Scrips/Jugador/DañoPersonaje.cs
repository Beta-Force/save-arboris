using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DañoPersonaje : MonoBehaviour
{

    public int MaxVida = 100;
    public int SaludActual;

    public float knockbackForce = 5.0f;
    public float DuracionRetroceso = 0.5f;

    private Rigidbody playerRigidbody;
    private bool TomandoDaño;

    private void Start()
    {
        SaludActual = MaxVida;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void TomarDaño(int Daño)
    {
        if (!TomandoDaño)
        {
            SaludActual -= Daño;
            TomandoDaño = true;


            Vector3 RetrocesoDirection = -(transform.forward + Vector3.up).normalized;
            playerRigidbody.AddForce(RetrocesoDirection * knockbackForce, ForceMode.Impulse);

            Invoke(nameof(FinaliceRetroceso), DuracionRetroceso);
        }
    }

    private void FinaliceRetroceso()
    {
        TomandoDaño = false;
    }

    private void Update()
    {
        if (SaludActual <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}