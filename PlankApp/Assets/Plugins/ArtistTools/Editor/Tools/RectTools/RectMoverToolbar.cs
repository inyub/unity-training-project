using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

namespace ArtistTools.Tools
{
    public class RectMoverToolbar : Editor
    {

        public static void Mover(float moveMinX, float moveMinY, float moveMaxX, float moveMaxY)
        {
            foreach (Transform _obj in Selection.transforms)
            {
                EditorGUI.BeginChangeCheck();
                Undo.RecordObject(_obj, "Changed Area Of Effect");
                RectTransform obj = _obj as RectTransform;
                if (obj == null) return;

                float currentMinX = obj.GetComponent<RectTransform>().anchorMin.x;
                float currentMinY = obj.GetComponent<RectTransform>().anchorMin.y;
                float currentMaxX = obj.GetComponent<RectTransform>().anchorMax.x;
                float currentMaxY = obj.GetComponent<RectTransform>().anchorMax.y;
                obj.GetComponent<RectTransform>().anchorMin = new Vector2(currentMinX + moveMinX, currentMinY + moveMinY);
                obj.GetComponent<RectTransform>().anchorMax = new Vector2(currentMaxX + moveMaxX, currentMaxY + moveMaxY);
                EditorGUI.EndChangeCheck();
            }
        }



        [MenuItem("ArtistTools/Rect Mover/Commands/Center Rect %1")]
        public static void CenterRect()
        {
            foreach (Transform gO in Selection.transforms)
            {
                EditorGUI.BeginChangeCheck();
                Undo.RecordObject(gO, "Changed Area Of Effect");
                RectTransform goRect = gO as RectTransform;
                if (goRect == null) return;
                //float widthCalc = goRect.rect.width / 2;
                //float heightCalc = goRect.rect.height / 2;
                gO.transform.localPosition = new Vector3(0, 0, 0);
                RectHandler.SnapToOffset();
                EditorGUI.EndChangeCheck();
            }
        }
    }

}

