using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUpgradePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel;
    
    public void OpenPanel()
    {
        Debug.Log("Click");
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }
}
