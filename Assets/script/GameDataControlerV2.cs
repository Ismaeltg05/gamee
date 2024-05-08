using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataControlerV2 : MonoBehaviour
{

    public GameObject jugador;
    public string archivoDeGuardado;
    public DatosJuego datosJuego = new DatosJuego();
    private void Awake()
    {
        archivoDeGuardado = Application.dataPath + "/datosJuego.json";

        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    private void CargarDatos()
    {
        if(File.Exists(archivoDeGuardado))
        {
            string contenido = File.ReadAllText(archivoDeGuardado);

            Debug.Log("" + contenido);

            datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);

            Debug.Log("Posicion Jugador: " + datosJuego.posicion);

            jugador.transform.position = datosJuego.posicion;
        }
        else
        {
            Debug.Log("El archivo no existe");
        }
    }

    private void GuardarDatos()
    {
        DatosJuego nuevosDatos =  new()
        {
            posicion = jugador.transform.position
        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(archivoDeGuardado, cadenaJSON);

        Debug.Log("Archivo Guardado");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            CargarDatos();
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            GuardarDatos();
        }
    }
}

//MVC

// PlayerData
    //  Vector3 Position
    //  int stamina

//PlayerController : Monobehaviour
    // Jump
    // Walk
    // TakeDamage
    // SpendStamina
        // PlayerData.Stamina -= staminaAmount

//PlayerHUD : Monobehaviour
    // Slider staminaSlider
