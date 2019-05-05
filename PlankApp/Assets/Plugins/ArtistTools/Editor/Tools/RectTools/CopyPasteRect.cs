using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

namespace ArtistTools.Tools
{
    public class CopyPasteRect : EditorWindow
    {
        public Vector2 copyAnchorMin, copyAnchorMax, copyOffsetMin, copyOffsetMax, copyPivot;
        public Quaternion copyRotate;

        [MenuItem("ArtistTools/Tools/Copy Paste Rect")]
        public static void ShowWindow()
        {
            EditorWindow editorWin = EditorWindow.GetWindow(typeof(CopyPasteRect));
            editorWin.minSize = new Vector2(62f, 20f);
            // editorWin.maxSize = editorWin.minSize;
        }

        void OnGUI()
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Copy\nRect"/* , GUILayout.Width(54), GUILayout.Height(50) */))
            {
                foreach (Transform transform in Selection.transforms)
                {
                    RectTransform thisTransform = transform as RectTransform;
                    if (thisTransform == null) return;
                    copyAnchorMin = thisTransform.GetComponent<RectTransform>().anchorMin;
                    copyAnchorMax = thisTransform.GetComponent<RectTransform>().anchorMax;
                    copyOffsetMin = thisTransform.GetComponent<RectTransform>().offsetMin;
                    copyOffsetMax = thisTransform.GetComponent<RectTransform>().offsetMax;
                    copyPivot = thisTransform.GetComponent<RectTransform>().pivot;
                    copyRotate = thisTransform.GetComponent<Transform>().rotation;
                }
            }
            if (GUILayout.Button("Paste\nRect"/* , GUILayout.Width(54), GUILayout.Height(50) */))
            {
                foreach (Transform transform in Selection.transforms)
                {
                    RectTransform thisTransform = transform as RectTransform;
                    if (thisTransform == null) return;
                    Undo.RecordObject(thisTransform, "Pasted Rect");
                    thisTransform.GetComponent<RectTransform>().anchorMin = copyAnchorMin;
                    thisTransform.GetComponent<RectTransform>().anchorMax = copyAnchorMax;
                    thisTransform.GetComponent<RectTransform>().offsetMin = copyOffsetMin;
                    thisTransform.GetComponent<RectTransform>().offsetMax = copyOffsetMax;
                    thisTransform.GetComponent<RectTransform>().pivot = copyPivot;
                    thisTransform.GetComponent<Transform>().rotation = copyRotate;
                }
            }
            GUILayout.EndHorizontal();
        }

    }

}

