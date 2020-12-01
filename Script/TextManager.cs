using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public string[] scenarios;
    public Text uiText;
    int current = 0;

    public string[] names;
    public Text nameText;
    public GameObject namePanel;

    public GameObject mainPanel;

    string currentText = string.Empty;  //文字列
    float textSpeed = 0.05f;            //1文字表示にかかる時間
    float timeUntilDisplay = 0;         //文字表示にかかる時間
    float timeElapsed = 1;              //文字表示を開始した時刻
    float lastUpdate = -1;              //文字表示が終わった時刻

    SpriteRenderer MainSprite;
    public Sprite[] faces;

    public bool CompleteCheck
    {
        get { return Time.time > timeElapsed + timeUntilDisplay; }
    }

    // Start is called before the first frame update
    void Start()
    {
        MainSprite = GetComponent<SpriteRenderer>();

        mainPanel = GameObject.Find("MainPanel");
        namePanel = GameObject.Find("NamePanel");

        scenarios = new string[]
        {
            "…………あれ、ここはどこだ？",            
            "「あっ、やっと起きたんだね」",
            "「…………え？」",
            "「おはよう。気分はどうかな？」",
            "目の前に全く知らない女の子がいた。",
            "「…………誰？」",
            "「私はユニティちゃん！みんなからそう呼ばれているの！」",
            "変わった名前だなあ。",
            "「ねえ、よかったら私とお話しない？」",
            "話か……特にここがどこか知りたいしなあ。",         //10行目、分岐
            "「うん、いいよ」",
            "「やったあ！」",
            "「ところで、ここってどこなの？」",
            "「ここはユニティタウンの学校だよ」",
            "ユニティタウン……全然知らない。電車とかバスとかどうやって乗り継げばいいのか",
            "「ちゃんと帰れるのか不安になってるでしょ」",
            "「え、分かるの？」",
            "「うん、君みたいに突然ここに来ちゃう人たまにいるから。でも大丈夫だよ、私帰り方知ってるから」",
            "「本当に！？」",
            "思わず身を乗り出してしまった。ユニティちゃんが驚いているようだ",
            "「ああ、ごめん」",
            "「あはは、大丈夫だよ。まあ帰り方は後で教えてあげるから。その前に君の住んでいる所とかいろいろ教えてよ」",
            "「よし、任せろ」",
            "俺はユニティちゃんと話をした後帰り方を教えてもらい無事に帰ることができた。",
            "　",
        };

        names = new string[]
        {
            "",
            "???",
            "俺",
            "???",
            "",
            "俺",
            "ユニティちゃん",
            "",
            "ユニティちゃん",
            "",
            "俺",
            "ユニティちゃん",
            "俺",
            "ユニティちゃん",
            "",
            "ユニティちゃん",
            "俺",
            "ユニティちゃん",
            "俺",
            "",
            "俺",
            "ユニティちゃん",
            "俺",
            "",
            "",

        };
    }

    // Update is called once per frame
    void Update()
    {
        if(current == 0)
        {
            currentText = scenarios[current];
            MainSprite.sprite = faces[current];
            nameText.text = names[current];
            current++;

            timeUntilDisplay = currentText.Length * textSpeed;
            timeElapsed = Time.time;

            lastUpdate = -1;
        }

        if (CompleteCheck)
        {
            if (current < scenarios.Length && Input.GetMouseButtonDown(0))
            {
                currentText = scenarios[current];
                MainSprite.sprite = faces[current];
                nameText.text = names[current];
                current++;

                timeUntilDisplay = currentText.Length * textSpeed;
                timeElapsed = Time.time;

                lastUpdate = -1;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                timeUntilDisplay = 0;
            }
        }

        int displayText = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);

        if (displayText != lastUpdate)
        {
            uiText.text = currentText.Substring(0, displayText);
            lastUpdate = displayText;
        }

        if(current == 25)
        {
            Destroy(mainPanel);
            Destroy(namePanel);
        }
    }
}
