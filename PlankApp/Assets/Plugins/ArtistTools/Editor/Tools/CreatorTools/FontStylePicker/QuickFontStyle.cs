using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.UI;
using ArtistTools.Tools;

namespace ArtistTools.Tools
{
    public class QuickFontStyle : EditorWindow
    {
        public FontStylePreset[] myPresets = {};

        #region GUI
        [MenuItem("ArtistTools/Tools/Font Style Picker")]
        public static void ShowWindow()
        {
            EditorWindow win = EditorWindow.GetWindow(typeof(QuickFontStyle));
            win.titleContent = new GUIContent("Font Style Picker");
        }

        void OnGUI()
        {
            ScriptableObject target = this;
            SerializedObject so = new SerializedObject(target);
            SerializedProperty fontStylePresetProperty = so.FindProperty("myPresets");

            EditorGUILayout.PropertyField(fontStylePresetProperty, true);

            so.ApplyModifiedProperties();

            for(int i = 0; i < myPresets.Length; i++)
            {
                if (myPresets[i] != null)
                {
                    if (GUILayout.Button("Font Style: " + myPresets[i].styleName))
                    {
                        InsertTextStyle(myPresets[i].styleName,
                                        myPresets[i].textMeshProAsset,
                                        myPresets[i].textMeshProStyle,
                                        myPresets[i].textFontStyle,
                                        myPresets[i].fontSize,
                                        myPresets[i].enableAutoFontSize,
                                        myPresets[i].textAlignment,
                                        myPresets[i].charSpacing,
                                        myPresets[i].wordSpacing,
                                        myPresets[i].lineSpacing,
                                        myPresets[i].parSpacing,
                                        myPresets[i].enableRaycastTarget);
                    }
                }
                else
                {
                    return;
                }
            }
        }
        #endregion

        #region Creator Function
        public static void InsertTextStyle(string fontText, TMP_FontAsset tmpAsset, Material mat, FontStyles fStyle, float fontSize, bool enableAutoFontSize, TextAlignmentOptions tmpAlignOpt, float cs, float ws, float ls, float ps,bool raycastOn)
        {
            foreach (Transform _txtTransform in Selection.transforms)
            {
                RectTransform txtTransform = _txtTransform as RectTransform;
                if (txtTransform == null) return;
                GameObject txtComponent = new GameObject(fontText + "Text");
                txtComponent.transform.parent = Selection.activeTransform;
                txtComponent.transform.localScale = Vector3.one;
                txtComponent.AddComponent<CanvasRenderer>();

                RectTransform rectComponent =  txtComponent.AddComponent<RectTransform>();
                rectComponent.transform.localPosition = Vector3.zero;
                rectComponent.anchorMin = new Vector2(0, 0);
                rectComponent.anchorMax = new Vector2(1, 1);
                rectComponent.offsetMin = new Vector2(0, 0);
                rectComponent.offsetMax = new Vector2(0, 0);

                TextMeshProUGUI tmproComp =  txtComponent.AddComponent<TextMeshProUGUI>();
                tmproComp.text = fontText;
                tmproComp.font = tmpAsset;
                tmproComp.fontMaterial = mat;
                tmproComp.fontStyle = fStyle;
                tmproComp.fontSize = fontSize;
                tmproComp.enableAutoSizing = enableAutoFontSize;
                tmproComp.alignment = tmpAlignOpt;
                tmproComp.characterSpacing = cs;
                tmproComp.wordSpacing = ws;
                tmproComp.lineSpacing = ls;
                tmproComp.paragraphSpacing = ps;
                tmproComp.raycastTarget = raycastOn;


                Debug.Log(fontText + " placed.");

                Selection.activeObject = txtComponent;
            }
            RectHandler.ResetOffset();
        }
        #endregion
    }
}
