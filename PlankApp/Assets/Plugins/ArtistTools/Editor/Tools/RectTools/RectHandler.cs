using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace ArtistTools.Tools
{
    public class RectHandler : Editor
    {
        [MenuItem("ArtistTools/Rect Handler/Commands/Beautify Numbers %2")]
        public static void BeautifyNumbers()
        {
            foreach (Transform transform in Selection.transforms)
            {
                RectTransform thisTransform = transform as RectTransform;
                if (thisTransform == null) return;

                float beautifyMinX = thisTransform.GetComponent<RectTransform>().anchorMin.x;
                float beautifyMinY = thisTransform.GetComponent<RectTransform>().anchorMin.y;
                float beautifyMaxX = thisTransform.GetComponent<RectTransform>().anchorMax.x;
                float beautifyMaxY = thisTransform.GetComponent<RectTransform>().anchorMax.y;

                //another way to do this: ...
                string minX = beautifyMinX.ToString("F3");
                string minY = beautifyMinY.ToString("F3");
                string maxX = beautifyMaxX.ToString("F3");
                string maxY = beautifyMaxY.ToString("F3");

                beautifyMinX = float.Parse(minX);
                beautifyMinY = float.Parse(minY);
                beautifyMaxX = float.Parse(maxX);
                beautifyMaxY = float.Parse(maxY);
                /*           
                beautifyMinX = Mathf.Round(beautifyMinX * 1000.0f) / 1000.0f;
                beautifyMinY = Mathf.Round(beautifyMinY * 1000.0f) / 1000.0f;
                beautifyMaxX = Mathf.Round(beautifyMaxX * 1000.0f) / 1000.0f;
                beautifyMaxY = Mathf.Round(beautifyMaxY * 1000.0f) / 1000.0f;
                */
                thisTransform.anchorMin = new Vector2(beautifyMinX, beautifyMinY);
                thisTransform.anchorMax = new Vector2(beautifyMaxX, beautifyMaxY);

                Debug.Log(beautifyMaxX);
            }
        }
        [MenuItem("ArtistTools/Rect Handler/Commands/Snap to Offset %3")]
        public static void SnapToOffset()
        {
            foreach (Transform transform in Selection.transforms)
            {
                RectTransform thisTransform = transform as RectTransform;
                RectTransform parentTransform = Selection.activeTransform.parent as RectTransform;

                if (thisTransform == null || parentTransform == null) return;

                Vector2 newAnchorsMin = new Vector2(thisTransform.offsetMin.x / parentTransform.rect.width + thisTransform.anchorMin.x,
                    thisTransform.offsetMin.y / parentTransform.rect.height + thisTransform.anchorMin.y);
                Vector2 newAnchorsMax = new Vector2(thisTransform.offsetMax.x / parentTransform.rect.width + thisTransform.anchorMax.x,
                    thisTransform.offsetMax.y / parentTransform.rect.height + thisTransform.anchorMax.y);

                thisTransform.anchorMin = newAnchorsMin;
                thisTransform.anchorMax = newAnchorsMax;

                thisTransform.offsetMin = thisTransform.offsetMax = new Vector2(0, 0);
            }

        }
        [MenuItem("ArtistTools/Rect Handler/Commands/Reset Offset %4")]
        public static void ResetOffset()
        {
            foreach (Transform transform in Selection.transforms)
            {
                RectTransform thisTransform = transform as RectTransform;
                thisTransform.offsetMin = new Vector2(55554455555555555, 55555555555555555); //just to overwrite the bug with the weird e-numbers
                thisTransform.offsetMax = new Vector2(55555555555555555, 55555555555555555);
                thisTransform.offsetMin = new Vector2(1, 1); //just to overwrite the bug with the weird e-numbers
                thisTransform.offsetMax = new Vector2(1, 1);
                thisTransform.offsetMin = new Vector2(0, 0);
                thisTransform.offsetMax = new Vector2(0, 0);
            }
        }


    }

}
