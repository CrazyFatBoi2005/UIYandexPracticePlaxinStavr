using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class NameTextScript : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _inputText;
        
    public void ChangeName()
    {
        _nameText.text = _inputText.text;
    }
}
