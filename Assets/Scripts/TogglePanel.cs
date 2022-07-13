using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject Panel;

    public static bool isActive = false;

    public void OpenPanel()
    {
        isActive = true;
        Panel.SetActive(isActive);
    }

    public void ClosePanel()
    {
        isActive = false;
        Panel.SetActive(isActive);
    }
}
