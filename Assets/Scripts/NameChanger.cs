using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameChanger : MonoBehaviour
{

    public TextMeshProUGUI _planetName;
    public TextMeshProUGUI _tourCount;


    public void SetCurrentPlanetInfo (string currentInput, string tour)
    {
        _planetName.text = "Planet's name: " + currentInput;
        _tourCount.text = "Tour Count: " + tour;
    }
}
