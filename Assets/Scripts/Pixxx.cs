
using UnityEditor;
using UnityEngine;

public class Pixxx : MonoBehaviour
{
    [Range(1,256)]public float Scale = 2;
    private float gg;

    private Camera cameraComponent;
    private RenderTexture texture;

    private void Start()
    {
        CreateTexture();
        gg = Scale;
    }

    private void CreateTexture()
    {
        int width = Mathf.RoundToInt(Screen.width / Scale);
        int height = Mathf.RoundToInt(Screen.height / Scale);
        texture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
        texture.antiAliasing = 1;

        cameraComponent = GetComponent<Camera>();
    }

    private void Update()
    {
        if (gg==Scale) return;
        CreateTexture();
        gg = Scale;
    }

    private void OnPreRender()
    {
        cameraComponent.targetTexture = texture;
    }

    private void OnPostRender()
    {
        cameraComponent.targetTexture = null;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        src.filterMode = FilterMode.Point;

        Graphics.Blit(src, dest);
    }
}