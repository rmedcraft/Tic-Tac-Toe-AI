using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public TicTacToeGame game;
    public TextMeshProUGUI pauseText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (pauseText != null) {
            pauseText.text = "";
        }
        if (game != null) {
            game.SetUI(this);
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnReset() {
        if (game != null && pauseText != null) {
            pauseText.text = "";
            game.ResetGame();
        }
    }
}
