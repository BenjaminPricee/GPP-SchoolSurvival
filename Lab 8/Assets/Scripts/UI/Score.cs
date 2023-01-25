using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI text;

    private void Update()
    {
        text.text = "Score : " + score;
    }

    public void ScoreDown()
    {
        score--;
    }
}
