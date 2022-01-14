using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIVariables : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject gameRun;
    private int score;
    private string scoreUI;
    
    void Start()
    {
        score = gameRun.GetComponent<ImageFade>().score;
        Debug.Log(score);
        Debug.Log(gameRun.GetComponent<ImageFade>().score);
        gameObject.GetComponent<TextMeshProUGUI>().text = score.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        score = gameRun.GetComponent<ImageFade>().score;
        gameObject.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
