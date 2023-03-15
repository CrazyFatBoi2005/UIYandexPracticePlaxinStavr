using System;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    [SerializeField] private ModelVariants _modelVariants;
    [SerializeField] public Material currentMaterial;
    

    public void SetMaterial(Material material)
    {
        currentMaterial = material;
        var currentRenderer =_modelVariants.currenSelected.GetComponent<Renderer>();
        currentRenderer.material = material;
    }

}
