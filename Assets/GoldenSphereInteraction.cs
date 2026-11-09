using UnityEngine;

/// <summary>Responds to the official Cardboard reticle's gaze messages.</summary>
[RequireComponent(typeof(Renderer), typeof(SphereCollider))]
public sealed class GoldenSphereInteraction : MonoBehaviour
{
    [SerializeField] private Color gazeColor = new Color(0.1f, 0.9f, 1f, 1f);
    [SerializeField, Range(1f, 1.5f)] private float gazeScale = 1.15f;

    private Material displayMaterial;
    private Color originalColor;
    private Vector3 originalScale;

    private void Awake()
    {
        // An instance keeps this object's color changes separate from other assets.
        displayMaterial = GetComponent<Renderer>().material;
        originalColor = displayMaterial.color;
        originalScale = transform.localScale;
    }

    public void OnPointerEnter()
    {
        if (!isActiveAndEnabled) return;
        displayMaterial.color = gazeColor;
        transform.localScale = originalScale * gazeScale;
    }

    public void OnPointerExit()
    {
        RestoreAppearance();
    }

    public void OnPointerClick()
    {
        // Keep the highlight when the Cardboard button is pressed while gazing.
        OnPointerEnter();
    }

    private void OnDisable()
    {
        RestoreAppearance();
    }

    private void RestoreAppearance()
    {
        if (displayMaterial == null) return;
        displayMaterial.color = originalColor;
        transform.localScale = originalScale;
    }

    private void OnDestroy()
    {
        if (displayMaterial != null) Destroy(displayMaterial);
    }
}
