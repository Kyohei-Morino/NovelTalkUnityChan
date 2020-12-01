using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToTitle : MonoBehaviour
{
    private float fadeSpeed = 0.01f;
    private float red, green, blue, alfa;
    public bool isFadeOut = false;
    private Image fadeImage;

    public GameObject mainPanel;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

        mainPanel = GameObject.Find("MainPanel");
    }

    // Update is called once per frame
    void Update()
    {
        if (mainPanel == null)
        {
            fadeImage.enabled = true;
            alfa += fadeSpeed;
            SetAlfa();
            if (alfa >= 1)
            {
                isFadeOut = false;
                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    void SetAlfa()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
