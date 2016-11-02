using UnityEngine;
using System.Collections;

public class CameraAlpha : MonoBehaviour
{

    [SerializeField]
    Material m_Material;

    [Range(0, 1)]
    public float Opacity = 1;

    void Update()
    {
        m_Material.SetFloat("_Opacity", Opacity);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, m_Material);
    }
}
