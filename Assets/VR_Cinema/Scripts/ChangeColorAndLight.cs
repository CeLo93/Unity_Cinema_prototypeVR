using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorAndLight : MonoBehaviour
{
    public GameObject bt_01;
    public GameObject bt_02;
    public GameObject bt_03;
    public GameObject bt_play;
    public GameObject bt_pause;

    private Material bt_01Material;
    private Material bt_02Material;
    private Material bt_03Material;
    private Material bt_playMaterial;
    private Material bt_pauseMaterial;

    private Color originalEmissionColor;

    void Start()
    {
        bt_01Material = bt_01.GetComponent<Renderer>().material;
        bt_02Material = bt_02.GetComponent<Renderer>().material;
        bt_03Material = bt_03.GetComponent<Renderer>().material;
        bt_playMaterial = bt_play.GetComponent<Renderer>().material;
        bt_pauseMaterial = bt_pause.GetComponent<Renderer>().material;

        originalEmissionColor = bt_01Material.GetColor("_EmissionColor");
    }

    void Update()
    {
        HandleInputs();
    }

    void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeEmissionColor(bt_01Material);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeEmissionColor(bt_02Material);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeEmissionColor(bt_03Material);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeEmissionColor(bt_playMaterial);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeEmissionColor(bt_pauseMaterial);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.R) || Input.GetKeyUp(KeyCode.P))
        {
            ResetEmissionColor(bt_01Material);
            ResetEmissionColor(bt_02Material);
            ResetEmissionColor(bt_03Material);
            ResetEmissionColor(bt_playMaterial);
            ResetEmissionColor(bt_pauseMaterial);
        }
    }

    void ChangeEmissionColor(Material material)
    {
        // Alterar a emissão de cor do material para amarelo
        material.SetColor("_EmissionColor", Color.yellow);
        material.EnableKeyword("_EMISSION");
    }

    void ResetEmissionColor(Material material)
    {
        // Restaurar a emissão de cor original do material
        material.SetColor("_EmissionColor", originalEmissionColor);
        material.DisableKeyword("_EMISSION");
    }
}
