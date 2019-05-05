using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using ArtistTools.Tools;

namespace ArtistTools.Tools
{
    public class CreatorButtonsEditor : EditorWindow
    {
        string newName;
        public float moveSteps = 0.05f;
        public float moveMinX, moveMinY, moveMaxX, moveMaxY;


        [MenuItem("ArtistTools/Creator Buttons/Creator Buttons")]
        public static void ShowWindow()
        {
            EditorWindow editorWin = EditorWindow.GetWindow(typeof(CreatorButtonsEditor));
            editorWin.minSize = new Vector2(62f, 30f);
            // editorWin.maxSize = editorWin.minSize;
        }
        void OnGUI()
        {

            GUIStyle customButton = new GUIStyle("button");
            customButton.fontSize = 45;

            GUILayout.BeginHorizontal();

            //Creator
            if (GUILayout.Button("Empty", GUILayout.Width(54), GUILayout.Height(50)))
            {
                CreatorButtons.InsertEmpty();
            }
            if (GUILayout.Button("❀", customButton, GUILayout.Width(54), GUILayout.Height(50)))
            {
                CreatorButtons.InsertImage();
            }
            if (GUILayout.Button("Text", GUILayout.Width(54), GUILayout.Height(50)))
            {
                CreatorButtons.InsertText();
            }
            if (GUILayout.Button("Button", GUILayout.Width(54), GUILayout.Height(50)))
            {
                CreatorButtons.InsertButton();

            }


            GUILayout.BeginVertical();
            if (GUILayout.Button("A", GUILayout.Width(25), GUILayout.Height(23)))
            {
                CreatorButtons.AddAspectRatioFitter();
            }
            /* if (GUILayout.Button("G", GUILayout.Width(25), GUILayout.Height(23)))
            {
                CreatorButtons.AddCustomGradient();
            } */
            if (GUILayout.Button("eFx", GUILayout.Width(25), GUILayout.Height(23)))
            {
                CreatorButtons.AddUiParticle();
            }
            GUILayout.EndVertical();


            GUILayout.EndHorizontal();
            this.Repaint();
        }
    }
}

