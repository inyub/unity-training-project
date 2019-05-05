using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using ArtistTools.Tools;

namespace ArtistTools.Tools
{
    public class RectMoverToolbarEditor : EditorWindow
    {
        public float moveSteps = 0.05f;
        public float moveMinX, moveMinY, moveMaxX, moveMaxY;

        [MenuItem("ArtistTools/Rect Mover/Rect Mover")]
        public static void ShowWindow()
        {
            EditorWindow editorWin = EditorWindow.GetWindow(typeof(RectMoverToolbarEditor));
            editorWin.minSize = new Vector2(62f, 222f);
            // editorWin.maxSize = editorWin.minSize;
        }

        void OnGUI()
        {

            if (Selection.activeTransform == false)
            {
                GUI.skin.label.alignment = TextAnchor.MiddleCenter;
                GUILayout.Label("Select\nan\nUI\nelement", EditorStyles.boldLabel);
                GUI.skin.label.alignment = TextAnchor.MiddleLeft;
            }
            else
            {
                //Mover
                GUI.backgroundColor = Color.grey;
                if (Selection.activeTransform)
                {
                    GUI.BeginGroup(new Rect(0, 2, 62, 222));
                    GUI.Box(new Rect(1, 1, 60, 220), "Move it!");
                    GUI.backgroundColor = Color.white;


                    // input
                    GUI.skin.textField.alignment = TextAnchor.MiddleCenter;
                    moveSteps = EditorGUI.FloatField(new Rect(4, 20, 54, 20), "", moveSteps);
                    GUI.skin.textField.alignment = TextAnchor.MiddleLeft;
                    moveMinX = moveSteps;
                    moveMinY = moveSteps;
                    moveMaxX = moveSteps;
                    moveMaxY = moveSteps;

                    //move up
                    if (GUI.Button(new Rect(21, 45, 20, 18), "▲"))
                    {
                        RectMoverToolbar.Mover(moveMinX = 0, moveMinY, moveMaxX = 0, moveMaxY);
                    }

                    //move left
                    if (GUI.Button(new Rect(3, 63, 20, 18), "◀"))
                    {
                        RectMoverToolbar.Mover(moveMinX * (-1), moveMinY = 0, moveMaxX * (-1), moveMaxY = 0);
                    }

                    //move right
                    if (GUI.Button(new Rect(39, 63, 20, 18), "▶"))
                    {
                        RectMoverToolbar.Mover(moveMinX, moveMinY = 0, moveMaxX, moveMaxY = 0);
                    }

                    //move down
                    if (GUI.Button(new Rect(21, 82, 20, 18), "▼"))
                    {
                        RectMoverToolbar.Mover(moveMinX = 0, moveMinY * (-1), moveMaxX = 0, moveMaxY * (-1));
                    }

                    //move to center
                    if (GUI.Button(new Rect(26, 67, 10, 10), ""))
                    {
                        RectMoverToolbar.CenterRect();
                    }

                    //move up+left
                    if (GUI.Button(new Rect(6, 48, 10, 10), ""))
                    {
                        RectMoverToolbar.Mover(moveMinX * (-1), moveMinY, moveMaxX * (-1), moveMaxY);
                    }

                    //move up+right
                    if (GUI.Button(new Rect(45, 48, 10, 10), ""))
                    {
                        RectMoverToolbar.Mover(moveMinX, moveMinY, moveMaxX, moveMaxY);
                    }

                    //move down+left
                    if (GUI.Button(new Rect(6, 86, 10, 10), ""))
                    {
                        RectMoverToolbar.Mover(moveMinX * (-1), moveMinY * (-1), moveMaxX * (-1), moveMaxY * (-1));
                    }

                    //move down+right
                    if (GUI.Button(new Rect(45, 86, 10, 10), ""))
                    {
                        RectMoverToolbar.Mover(moveMinX, moveMinY * (-1), moveMaxX, moveMaxY * (-1));
                    }

                    //wider
                    if (GUI.Button(new Rect(4, 112, 54, 25), "← →"))
                    {
                        RectMoverToolbar.Mover(moveMinX * (-1), moveMinY = 0, moveMaxX, moveMaxY = 0);
                    }

                    //slimmer
                    if (GUI.Button(new Rect(4, 140, 54, 25), "→ ←"))
                    {
                        RectMoverToolbar.Mover(moveMinX, moveMinY = 0, moveMaxX * (-1), moveMaxY = 0);
                    }

                    //taller
                    if (GUI.Button(new Rect(4, 168, 25, 45), "↑\n↓"))
                    {
                        RectMoverToolbar.Mover(moveMinX = 0, moveMinY * (-1), moveMaxX = 0, moveMaxY);
                    }

                    //smaller
                    if (GUI.Button(new Rect(33, 168, 25, 45), "↓\n↑"))
                    {
                        RectMoverToolbar.Mover(moveMinX = 0, moveMinY, moveMaxX = 0, moveMaxY * (-1));
                    }
                    GUI.EndGroup();
                }
            }
            this.Repaint();
        }
    }

}

