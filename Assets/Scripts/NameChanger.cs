using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameChanger : MonoBehaviour
{

    public TextMeshProUGUI _planetName;
    //public TextMeshProUGUI _tourCount;

    public void SetCurrentPlanetName (string currentInput)
    {
        _planetName = FindObjectOfType<TextMeshProUGUI>();
        _planetName.SetText($"Planet's name: {currentInput}");
    }
    //public void SetCurrentTourCount (string tour)
    //{
    //    _tourCount = FindObjectOfType<TextMeshProUGUI>();
    //    _tourCount.SetText($"Tour count: {tour}");
    //}
}
