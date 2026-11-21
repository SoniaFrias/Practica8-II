using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CarBehaviour.OnUpdateScore += ScoreChange;
        score = 0;
        text.text = $"Puntuación: {score}";
    }

    // Update is called once per frame
    void ScoreChange(int change) {
        score += change;
        text.text = $"Puntuación: {score}";
    }
}
