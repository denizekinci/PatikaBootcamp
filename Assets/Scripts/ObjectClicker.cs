using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    NameChanger _planetName;

    TogglePanel _togglePanel;

    GameObject selectedGameObject;

    private void Start()
    {
        _planetName = GameObject.FindObjectOfType(typeof(NameChanger)) as NameChanger;
        _togglePanel = GameObject.FindObjectOfType(typeof(TogglePanel)) as TogglePanel;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    selectedGameObject = hit.transform.gameObject;
                    _togglePanel.OpenPanel();
                    _planetName.SetCurrentPlanetName(selectedGameObject.name.ToString());
                }
            }
        }
    }
}
