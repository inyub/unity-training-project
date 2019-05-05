using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
using ArtistTools.Tools;

namespace ArtistTools.Tools
{
    public class RectHandlerEditor : EditorWindow
    {

        [MenuItem("ArtistTools/Rect Handler/Rect Handler")]
        public static void ShowWindow()
        {
            EditorWindow editorWin = EditorWindow.GetWindow(typeof(RectHandlerEditor));
            //EditorWindow editorWin =  new EditorWindow();
            editorWin.minSize = new Vector2(10.0f, 30f);
            //editorWin.maxSize = editorWin.minSize;
        }

        void OnGUI()
        {
            GUIStyle smallFont = new GUIStyle("button");
            smallFont.fontSize = 9;

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Offset\nSnap"/* , GUILayout.Width(54), GUILayout.Height(50) */))
            {
                RectHandler.SnapToOffset();
            }
            if (GUILayout.Button("Offset\nReset"/* , GUILayout.Width(54), GUILayout.Height(50) */))
            {
                RectHandler.ResetOffset();
            }
            if (GUILayout.Button("Beautify\nAnchors"/* , smallFont, GUILayout.Width(54), GUILayout.Height(50) */))
            {
                RectHandler.BeautifyNumbers();
            }

            GUILayout.EndHorizontal();

        }
    }

}
