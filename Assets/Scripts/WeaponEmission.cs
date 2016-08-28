using UnityEngine;
using System.Collections;

public class WeaponEmission : MonoBehaviour
{
    [SerializeField]
    private Renderer renderer;
    [SerializeField, Range(0, 1)]
    private float brightness;

    public float Brightness
    {
        get
        {
            return brightness;
        }
        set
        {
            this.brightness = value;
            renderer.sharedMaterial.SetColor("_EmissionColor", emissionColor * brightness);
        }
    }

    public Color emissionColor;

    void OnValidate()
    {
        Brightness = brightness;
    }

    
}
