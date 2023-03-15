using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ModelVariants : MonoBehaviour
{
    [HideInInspector] public GameObject currenSelected;
    
    [SerializeField] private GameObject[] _models;
    [SerializeField] private TMP_Dropdown _dropdown;

    private void Start()
    {
        currenSelected = _models[0];

        List<TMP_Dropdown.OptionData> _optionDataList = new List<TMP_Dropdown.OptionData>();
        foreach (var item in _models)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = item.name;
            _optionDataList.Add(data);
        }
        _dropdown.options = _optionDataList;

        _dropdown.onValueChanged.AddListener(Select);

    }

    public void Select(int index) {
        currenSelected.SetActive(false);
        currenSelected = _models[index];
        currenSelected.SetActive(true);
    }


}
