using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject shatterableObject;
    public void OpenPanel()
    {
        bool isActive = panel.activeSelf;
        panel.SetActive(!isActive);
    }

   
}
