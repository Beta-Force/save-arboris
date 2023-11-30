using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Opciones : MonoBehaviour
{
    [Header("Volumen")]
    public Slider volumen;
    public float volumenValue;
    public Image imagenMute;

    [Header("Brillo")]
    public Slider Brillo;
    public float brilloValue;
    public Image panelBrillo;

    [Header("Toggel")]
    public Toggle toggle;

    [Header("calidad")]
    public TMP_Dropdown DpDcalidad;
    public int Calidad;

    [Header("Resolución")]
    public TMP_Dropdown Resoluciones;
    Resolution[] resolutions;

    [Header("Cerrar Opciones")]
    public GameObject optionsPanel;
    public GameObject coverPanel;


    private void Start()
    {
        //Modificar el volumen
        volumen.value = PlayerPrefs.GetFloat("volumenAudio", 1f);
        AudioListener.volume = volumen.value;
        RevisarSiEstoyMute();

        //Modificarl el brillo
        Brillo.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, Brillo.value);

        //Poner en pantalla completa
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        RevisarResoluciones();

        //Cambiar Calidad
        Calidad = PlayerPrefs.GetInt("numeroDeCalidad", 3);
        DpDcalidad.value = Calidad;
        AjustarCalidad();
    }

    public void ChangeVolumen(float valor)
    {
        volumenValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", volumenValue);
        AudioListener.volume = volumen.value;
        RevisarSiEstoyMute();
    }
    public void RevisarSiEstoyMute()
    {
        if (volumenValue == 0)
        {

            imagenMute.enabled = true;

        }
        else
        {
            imagenMute.enabled = false;
        }
    }

    public void ChangeBrillo(float valor)
    {

        brilloValue = valor;
        PlayerPrefs.SetFloat("brillo", brilloValue);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, Brillo.value);

    }

    public void OnPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(DpDcalidad.value);
        PlayerPrefs.SetInt("numeroDeCalidad", DpDcalidad.value);
        Calidad = DpDcalidad.value;
    }

    public void RevisarResoluciones()
    {
        resolutions = Screen.resolutions;
        Resoluciones.ClearOptions();
        List<string> Opciones = new List<string>();
        int resolucionActual = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string opcion = resolutions[i].width + " x " + resolutions[i].height;
            Opciones.Add(opcion);

            if(Screen.fullScreen&&resolutions[i].width==Screen.currentResolution.width&&
                resolutions[i].height==Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }

        Resoluciones.AddOptions(Opciones);
        Resoluciones.value = resolucionActual;
        Resoluciones.RefreshShownValue();
    }

    public void CambiarResolución(int indiceResoluciones)
    {
        Resolution resolucion = resolutions[indiceResoluciones];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }


    public void OptionsPanel()
    {//START

        optionsPanel.SetActive(true);
        coverPanel.SetActive(false);
    }//END

    public void ClosesOptions()
    {//START
        optionsPanel.SetActive(false);
        coverPanel.SetActive(true);
    }//END

    public void Enlaces(string enlace)
    {
        Application.OpenURL(enlace);
    }
}
