using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Serialization;
//using UnityEngine.UI.Extensions;
using TMPro;
//using UiParticles;

namespace ArtistTools.Tools
{
    public class CreatorButtons : Editor
    {
        [MenuItem("ArtistTools/Creator Buttons/Commands/Insert Empty %6")]
        public static void InsertEmpty()
        {
            foreach (Transform _emptyTransform in Selection.transforms)
            {
                RectTransform emptyTransform = _emptyTransform as RectTransform;
                if (emptyTransform == null) return;
                GameObject go = new GameObject("Empty");
                go.transform.parent = Selection.activeTransform;
                go.transform.localPosition = Vector3.zero;
                go.transform.localRotation = Quaternion.identity;
                go.transform.localScale = Vector3.one;
                go.AddComponent<RectTransform>();

                Selection.activeObject = go;
            }

        }
        [MenuItem("ArtistTools/Creator Buttons/Commands/Insert Image %7")]
        public static void InsertImage()
        {
            foreach (Transform _imgTransform in Selection.transforms)
            {
                RectTransform imgTransform = _imgTransform as RectTransform;
                if (imgTransform == null) return;
                GameObject img = new GameObject("Image");
                img.transform.parent = Selection.activeTransform;
                img.transform.localScale = Vector3.one;

                img.AddComponent<RectTransform>();
                img.GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
                img.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                img.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                img.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                img.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);  

                img.AddComponent<CanvasRenderer>();
                img.AddComponent<Image>();
                img.GetComponent<Image>().raycastTarget = false;

                Selection.activeObject = img;
            }

        }
        [MenuItem("ArtistTools/Creator Buttons/Commands/Insert Text %8")]
        public static void InsertText()
        {
            foreach (Transform _txtTransform in Selection.transforms)
            {
                RectTransform txtTransform = _txtTransform as RectTransform;
                if (txtTransform == null) return;
                GameObject txtComponent = new GameObject("Text");
                txtComponent.transform.parent = Selection.activeTransform;
                txtComponent.AddComponent<RectTransform>();
                txtComponent.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                txtComponent.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                txtComponent.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                txtComponent.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                txtComponent.GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
                txtComponent.transform.localScale = Vector3.one;
                txtComponent.AddComponent<CanvasRenderer>();
                txtComponent.AddComponent<TextMeshProUGUI>();
                txtComponent.GetComponent<TextMeshProUGUI>().raycastTarget = false;

                Selection.activeObject = txtComponent;
                //will be exchanged with TextMeshPro once I am back @ work.
            }
        }

        [MenuItem("ArtistTools/Creator Buttons/Commands/Insert Button %9")]
        public static void InsertButton()
        {
            foreach (Transform _btnTransform in Selection.transforms)
            {
                RectTransform btnTransform = _btnTransform as RectTransform;
                if (btnTransform == null) return;
                GameObject btnComponent = new GameObject("Button");
                btnComponent.transform.parent = Selection.activeTransform;
                btnComponent.AddComponent<RectTransform>();
                btnComponent.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                btnComponent.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                btnComponent.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                btnComponent.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                btnComponent.GetComponent<RectTransform>().transform.localPosition = Vector3.zero;
                btnComponent.transform.localScale = Vector3.one;

                btnComponent.AddComponent<CanvasRenderer>();
                btnComponent.AddComponent<Image>();
                btnComponent.AddComponent<Button>();
                Selection.activeObject = btnComponent;
            }
        }

        [MenuItem("ArtistTools/Creator Buttons/Commands/Add Aspect Ratio Fitter %0")]
        public static void AddAspectRatioFitter()
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.AddComponent(typeof(AspectRatioFitter));
            }
        }
        /*[MenuItem ("Art/Commands/Add Gradient %0")]
        public static void AddCustomGradient()
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.AddComponent<CustomGradient>();           
            }
        }*/



        public static void AddUiParticle()
        {
            foreach (Transform _psTransform in Selection.transforms)
            {
                RectTransform emptyTransform = _psTransform as RectTransform;
                if (emptyTransform == null) return;
                GameObject go = new GameObject("PS_New");
                go.transform.parent = Selection.activeTransform;
                go.transform.localPosition = Vector3.zero;
                go.transform.localRotation = Quaternion.identity;
                //go.transform.localScale = Vector3.one;
                go.transform.localScale = new Vector3(50, 50, 0);
                go.AddComponent<RectTransform>();
                go.AddComponent<ParticleSystem>();
                //go.GetComponent<ParticleSystem>().shape

                //go.AddComponent<UiParticles.UiParticles>();
                //go.GetComponent<UiParticles.UiParticles>().raycastTarget = false;

                Selection.activeObject = go;
            }

        }

    }
}

