using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour

{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject shatterableObject;
    public GameObject playerController;
    public GameObject[] otherPanels;

    public void OpenPanel()
    {
        bool isActive = panel.activeSelf;
        panel.SetActive(!isActive);
        if (!isActive)
        {
            playerController.GetComponent<PlayerController>().uiAccessed = true;
        }
        else
        {
            playerController.GetComponent<PlayerController>().uiAccessed = false;
        }
        foreach (GameObject otherPanel in otherPanels)
        {
            if (otherPanel.activeSelf)
            {
                otherPanel.SetActive(false);
            }
        }
    }

   
}
