using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PathMediator : MonoBehaviour
{
    [SerializeField] private PathCard _pathCard;

    [Header("Background")]
    [SerializeField] private Image _bgImage;
    [SerializeField] private Sprite _bgSpriteInactive;
    [SerializeField] private Sprite _bgSpriteActive;
    [SerializeField] private bool _pathActive;
    [Header("Slider")]
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _fillGO;
    [SerializeField] private bool _fillActive;
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _length;
    [SerializeField] private TextMeshProUGUI _goal;
    [Header("Icon")]
    [SerializeField] private Image _icon;

    [Header("Other UI")]
    [SerializeField] private TextMeshProUGUI _sliderDescription;
    [SerializeField] private TextMeshProUGUI _cardNav;
    [SerializeField] private GameObject _trophy;
    [SerializeField] private bool _unlocked;

    [Header("Path")]
    [SerializeField] private GameObject _path;
    [SerializeField] private TextMeshProUGUI _pathTitle;
    [SerializeField] private TextMeshProUGUI _pathGoal;
    [SerializeField] private GameObject _levelNode;
    [SerializeField] private Transform _levelGrid;


    // Start is called before the first frame update
    void Start()
    {
        _fillGO.SetActive(_fillActive);
        _slider.maxValue = _pathCard.steps;
        _name.text = _pathCard.name;
        _length.text = _pathCard.length;
        _goal.text = _pathCard.goal;
        _icon.sprite = _pathCard.icon;
        _cardNav.text = "Locked";
        Debug.Log(transform.name + ": " + transform.GetSiblingIndex());
    }

    // Update is called once per frame
    void Update()
    {
        if (_unlocked)
            _cardNav.text = "Start now";

        if (_pathActive)
        {
            _bgImage.sprite = _bgSpriteActive;
            if (Mathf.Approximately(_pathCard.steps, _slider.value))
            {
                _cardNav.text = "Review";
                _trophy.SetActive(true);
            }
            else
            {
                _cardNav.text = "Continue";
                _trophy.SetActive(false);
            }
        }
        else
        {
            _bgImage.sprite = _bgSpriteInactive;
        }
    }

    public void CreatePath()
    {
        foreach (Transform child in _levelGrid)
        {
            Destroy(child.gameObject);
        }
        _pathTitle.text = _pathCard.name;
        _pathGoal.text = _pathCard.goal;
        for (int i = 0; i < _pathCard.steps; i++)
        {
            GameObject go;
            go = Instantiate(_levelNode);
            go.transform.SetParent(_levelGrid);
            go.GetComponentInChildren<TextMeshProUGUI>().text = (i+1).ToString();
        }

    }
}
