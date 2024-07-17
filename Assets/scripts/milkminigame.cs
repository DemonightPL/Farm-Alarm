using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class milkminigame : MonoBehaviour
{
    public Image movingIndicator;
    public Image targetArea;
    public Button clickButton;
    public TextMeshProUGUI resultText;
    public int score;
    public TextMeshProUGUI scoreText;
    public float speed = 200f;
    private bool movingRight = true;
    public GameObject cow;
    public Cow cowscript;

    private void Start()
    {
        cow= transform.parent.gameObject;
        cowscript = cow.GetComponent<Cow>();
        clickButton.onClick.AddListener(OnButtonClick);
        resultText.text = "";
    }

    private void Update()
    {
        MoveIndicator();
        if(score >= 10)
        {
            score = 0;
            cowscript.stopminigame();
            cowscript.milkspawn();

        }
    }

    private void MoveIndicator()
    {
        RectTransform indicatorRect = movingIndicator.GetComponent<RectTransform>();
        RectTransform targetRect = targetArea.GetComponent<RectTransform>();

        if (movingRight)
        {
            indicatorRect.anchoredPosition += Vector2.right * speed * Time.deltaTime;
            if (indicatorRect.anchoredPosition.x >= targetRect.rect.width * 2)
                movingRight = false;
        }
        else
        {
            indicatorRect.anchoredPosition -= Vector2.right * speed * Time.deltaTime;
            if (indicatorRect.anchoredPosition.x <= -targetRect.rect.width * 2)
                movingRight = true;
        }
    }

    private void OnButtonClick()
    {
        RectTransform indicatorRect = movingIndicator.GetComponent<RectTransform>();
        RectTransform targetRect = targetArea.GetComponent<RectTransform>();

        float indicatorPos = indicatorRect.anchoredPosition.x;
        float targetPos = targetRect.anchoredPosition.x;
        float targetWidth = targetRect.rect.width;

        if (Mathf.Abs(indicatorPos - targetPos) < targetWidth / 2)
        {
            resultText.text = "Success!";
            score +=1;
            scoreText.text = score.ToString();
            
        }
        else
        {
            resultText.text = "Missed!";
            if(score > 0)
            {
                    score -=1;
            }
            
             scoreText.text = score.ToString();
        }
    }
}
