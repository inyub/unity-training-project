using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NewFontStyle", menuName = "ArtistTool/New Font Style Preset", order = 1)]
public class FontStylePreset : ScriptableObject {
    [Header("The Font")]
    [Tooltip("Name(+Text) and Placeholder Text")]
    public string styleName;
    public TMP_FontAsset textMeshProAsset;
    public Material textMeshProStyle;
    [Header("Style Options")]
    public FontStyles textFontStyle = FontStyles.Normal;
    public float fontSize = 100f;
    public bool enableAutoFontSize = false;
    public TextAlignmentOptions textAlignment = TextAlignmentOptions.Center;
    [Header("Spacing Values")]
    public float charSpacing = 0;
    public float wordSpacing = 0;
    public float lineSpacing = 0;
    public float parSpacing = 0;
    [Header("Other")]
    public bool enableRaycastTarget = false;
}
