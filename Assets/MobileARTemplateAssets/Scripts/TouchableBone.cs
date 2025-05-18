using UnityEngine;

public class TouchableBone : MonoBehaviour
{
    private Material originalMaterial;
    private MeshRenderer meshRenderer;

    [TextArea]
    public string boneInfo;

    public Material highlightMaterial;

    // �u an se�ili olan par�a
    public static TouchableBone currentlySelected;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            originalMaterial = meshRenderer.material;
        }

        // Bu kemi�i y�neticide kaydet
        TouchableBoneManager.Instance?.RegisterBone(this);
    }


    public void OnTouched()
    {
        // Daha �nce se�ili olan varsa s�f�rla
        if (currentlySelected != null && currentlySelected != this)
        {
            currentlySelected.ResetMaterial();
        }

        // Bu par�ay� sar� yap
        if (meshRenderer != null && highlightMaterial != null)
        {
            meshRenderer.material = highlightMaterial;
        }

        // Bu par�ay� art�k aktif se�ili yap
        currentlySelected = this;

        // Bilgi panelini a�
        BoneInfoUI.Instance.ShowInfo(boneInfo);
    }

    public void ResetMaterial()
    {
        if (meshRenderer != null && originalMaterial != null)
        {
            meshRenderer.material = originalMaterial;
        }
    }

    public void SetTransparent(bool transparent)
    {
        if (meshRenderer == null || originalMaterial == null)
            return;

        Material mat = meshRenderer.material;

        if (transparent)
        {
            Color c = mat.color;
            c.a = 0.2f; // %20 g�r�n�r
            mat.color = c;

            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000;
        }
        else
        {
            Color c = mat.color;
            c.a = 1f;
            mat.color = c;

            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            mat.SetInt("_ZWrite", 1);
            mat.DisableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = -1;
        }
    }

}
