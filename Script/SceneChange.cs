using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private float fadeSpeed = 0.02f;
    private float red, green, blue, alfa;
    public bool isFadeOut = false;

    private Image fadeImage;
    public Button startButton;
        

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

        startButton.onClick.AddListener(StartFadeOut);  //Update関数に入れたらNG
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeOut == true)
        {
            UpdateFadeOut();
        }
    }

    void StartFadeOut()
    {        
        isFadeOut = true;

        UpdateFadeOut();       
        
    }

    void UpdateFadeOut()
    {
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlfa();
        if (alfa >= 1)
        {
            isFadeOut = false;
            SceneManager.LoadScene("MainScene");
        }
    }

    void SetAlfa()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
