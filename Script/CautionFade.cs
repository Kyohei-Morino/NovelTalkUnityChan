using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CautionFade : MonoBehaviour
{
    float fadeSpeed = 0.01f;
    float red, green, blue, alfa;
    public bool isFadeOut = false;
    public bool isFadeIn = false;

    private Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {
            UpdateFadeIn();
        }

        if (isFadeOut == true)
        {
            Invoke("UpdateFadeOut", 8f);
        }
    }

    void UpdateFadeIn()
    {        
        alfa -= fadeSpeed;

        if (Input.GetMouseButtonDown(0))
        {
            alfa = 0;
        }
        SetAlfa();
        if(alfa <= 0)
        {            
            isFadeIn = false;
            isFadeOut = true;
        }
    }

    void UpdateFadeOut()
    {
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlfa();
        if(alfa >= 1)
        {
            isFadeOut = false;
            SceneManager.LoadScene("TitleScene");
        }
    }

    void SetAlfa()
    {
        fadeImage.color = new Color(red, green, blue, alfa); 
    }
}
