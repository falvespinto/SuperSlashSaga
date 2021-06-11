using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testUltiVFX : MonoBehaviour
{

    public Renderer characterRenderer;
    public Renderer katanaRenderer;
    public Renderer capeRenderer;
    public Material flashMaterial;
    private Material[] playerTrueMaterials;
    private Material[] katanaTrueMaterials;
    private Material[] capeTrueMaterials;
    public bool flashActif;
    public bool flashInactif;
    Material[] katanaFlashMaterials;
    Material[] capeFlashMaterials;
    Material[] characterFlashMaterials;

    void Start()
    {
        playerTrueMaterials = characterRenderer.materials;
        katanaTrueMaterials = katanaRenderer.materials;
        capeTrueMaterials = capeRenderer.materials;
        katanaFlashMaterials = new Material[katanaRenderer.materials.Length];
        capeFlashMaterials = new Material[capeRenderer.materials.Length];
        characterFlashMaterials = new Material[characterRenderer.materials.Length];
        for (int i = 0; i < katanaFlashMaterials.Length; i++)
        {
            katanaFlashMaterials[i] = flashMaterial;
        }
        for (int i = 0; i < capeFlashMaterials.Length; i++)
        {
            capeFlashMaterials[i] = flashMaterial;
        }
        for (int i = 0; i < characterFlashMaterials.Length; i++)
        {
            characterFlashMaterials[i] = flashMaterial;
        }
    }

    public void startFlash()
    {
        characterRenderer.materials = characterFlashMaterials;
        katanaRenderer.materials = katanaFlashMaterials;
        capeRenderer.materials = capeFlashMaterials;
    }
    public void stopFlash()
    {
        characterRenderer.materials = playerTrueMaterials;
        katanaRenderer.materials = katanaTrueMaterials;
        capeRenderer.materials = capeTrueMaterials;
    }
    public void Flash(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            characterRenderer.materials = characterFlashMaterials;
            katanaRenderer.materials = katanaFlashMaterials;
            capeRenderer.materials = capeFlashMaterials;
        }
        if (ctx.canceled)
        {
            characterRenderer.materials = playerTrueMaterials;
            katanaRenderer.materials = katanaTrueMaterials;
            capeRenderer.materials = capeTrueMaterials;
        }
    }
    public void PasFlash(InputAction.CallbackContext ctx)
    {

    }


}
