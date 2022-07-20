using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    NameChanger _nameChanger;

    TogglePanel _togglePanel;

    GameObject selectedGameObject;
    
    string tourCount;


    private void Start()
    {
        _togglePanel = GameObject.FindObjectOfType(typeof(TogglePanel)) as TogglePanel;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 400.0f))
            {
                if (hit.transform != null)
                {
                    selectedGameObject = hit.transform.gameObject;

                    if(selectedGameObject.name != "Sun")
                    {
                        _togglePanel.OpenPanel();
                        _nameChanger = GameObject.FindObjectOfType(typeof(NameChanger)) as NameChanger;
                        
                        tourCount = selectedGameObject.GetComponent<OrbitsWithBezierCurve>().tour.ToString();
                        _nameChanger.SetCurrentPlanetInfo(selectedGameObject.name.ToString(), tourCount);
                    }
                }
            }
        }
    }
}