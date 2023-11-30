using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menú : MonoBehaviour

{

    void Start()
    {

    }

    void Update()
    {

    }

    public void CambiarDeNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
