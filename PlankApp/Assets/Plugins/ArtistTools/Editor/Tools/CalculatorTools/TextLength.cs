using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.UI;

namespace ArtistTools.Tools
{
    public class TextLength : EditorWindow
    {
        private string _inputText = "Type here";
        private int _textLength;
        private int _wordLength;
        private int _charCount;

        [MenuItem("ArtistTools/Tools/Text Length Calculator")]
        public static void ShowWindow()
        {
            GetWindow(typeof(TextLength));
        }

        private void OnGUI()
        {
            GUILayout.Label("Text Length Calculator", EditorStyles.boldLabel);
            _inputText = EditorGUILayout.TextField("How long is:", _inputText);
            _textLength = EditorGUILayout.IntField("Text Length: ", _textLength);
            _wordLength = EditorGUILayout.IntField("Word Count: ", _wordLength);
            _charCount = EditorGUILayout.IntField("Character Count: ", _charCount);

            _textLength = _inputText.Length;
            _wordLength = _inputText.Split().Length;
            _charCount = _inputText.Replace(" ", string.Empty).Length;

            GUILayout.BeginHorizontal();
            OnGetTextButtonClick();
            OnSetTextButtonClick();
            GUILayout.EndHorizontal();
            Repaint();
        }

        private void OnSetTextButtonClick()
        {
            if (GUILayout.Button("Set Text"))
            {
                foreach (GameObject selectedObject in Selection.gameObjects)
                {
                    if (selectedObject == null)
                    {
                        return;
                    }

                    Component label = GetLabel(selectedObject);

                    if (label == null)
                    {
                        continue;
                    }

                    Undo.RecordObject(selectedObject, "Changed Area Of Effect");

                    if (label.GetType() == typeof(TextMeshProUGUI))
                    {
                        ((TextMeshProUGUI)label).text = _inputText;
                        continue;
                    }

                    if (label.GetType() == typeof(Text))
                    {
                        ((Text)label).text = _inputText;
                    }
                }
            }
        }

        private void OnGetTextButtonClick()
        {
            if (GUILayout.Button("Get Text"))
            {
                foreach (GameObject selectedObject in Selection.gameObjects)
                {
                    if (selectedObject == null)
                    {
                        return;
                    }

                    Component label = GetLabel(selectedObject);

                    if (label == null)
                    {
                        continue;
                    }

                    if (label.GetType() == typeof(TextMeshProUGUI))
                    {
                        _inputText = ((TextMeshProUGUI)label).text;
                        continue;
                    }

                    if (label.GetType() == typeof(Text))
                    {
                        _inputText = ((Text)label).text;
                    }
                }
            }
        }

        private Component GetLabel(GameObject selectedObject)
        {
            Component label = selectedObject.GetComponent<TextMeshProUGUI>();
            return label != null ? label : selectedObject.GetComponent<Text>();
        }
    }
}

