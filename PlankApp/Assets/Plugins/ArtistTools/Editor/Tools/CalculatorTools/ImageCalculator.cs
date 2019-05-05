using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

namespace ArtistTools.Tools
{
    public class ImageCalculator : EditorWindow
    {

        float picWidth;
        float picHeight;
        //int imageWidth = 2;
        //int imageHeight = 2;
        float imageAspectRatio;
        Sprite thisImage = null;
        //Sprite usedImage;

        [MenuItem("ArtistTools/Tools/Aspect Ratio from Image")]

        public static void ShowWindow()
        {

            EditorWindow.GetWindow(typeof(ImageCalculator));
            // EditorWindow.GetWindowWithRect(typeof(AspectRatioPicker), new Rect(0, 0, 200, 100));
        }

        void OnGUI()
        {
            if (GUILayout.Button("Search", GUILayout.Height(50)))
            {
                int controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
                EditorGUIUtility.ShowObjectPicker<Sprite>(null, false, "", controlID);
                //what is happening here, what is controlID for?

            }
            string objectUpdated = Event.current.commandName;

            if (objectUpdated == "ObjectSelectorUpdated")
            {
                thisImage = EditorGUIUtility.GetObjectPickerObject() as Sprite;

                picWidth = thisImage.bounds.size.x;
                // imageWidth = (int)picWidth;
                picHeight = thisImage.bounds.size.y;
                //imageHeight = (int)picHeight;
                //this seems hacky to me, is there a more reasonable approach?

                imageAspectRatio = picWidth / picHeight;
                Repaint();
            }

            EditorGUILayout.ObjectField(thisImage, typeof(Sprite), true);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Aspect Ratio");
            EditorGUILayout.FloatField("", imageAspectRatio, GUILayout.MaxWidth(100));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Set width controls height", GUILayout.Height(25)))
            {
                foreach (GameObject obj in Selection.gameObjects)
                {
                    obj.AddComponent<AspectRatioFitter>();
                    /*usedImage = obj.GetComponent<Image> ().sprite;
                    if (usedImage != thisImage) {
                        thisImage = usedImage;
                    }*/
                    obj.GetComponent<Image>().sprite = thisImage;
                    obj.GetComponent<AspectRatioFitter>().aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
                    obj.GetComponent<AspectRatioFitter>().aspectRatio = imageAspectRatio;

                }
            }
            if (GUILayout.Button("Set height controls width", GUILayout.Height(25)))
            {
                foreach (GameObject obj in Selection.gameObjects)
                {
                    obj.AddComponent<AspectRatioFitter>();
                    obj.GetComponent<Image>().sprite = thisImage;
                    obj.GetComponent<AspectRatioFitter>().aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
                    obj.GetComponent<AspectRatioFitter>().aspectRatio = imageAspectRatio;

                }
            }
            GUILayout.EndHorizontal();


        }

    }

}

