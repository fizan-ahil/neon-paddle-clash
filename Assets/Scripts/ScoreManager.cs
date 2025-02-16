using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int scoretoreach;//how much score a player must reach inorder for the game to end.
    private int player1_score = 0;
    private int player2_score = 0;
    public TMP_Text player1_scoretext;
    public TMP_Text player2_scoretext;
    public void player1goal()
    {
        player1_score++;
        player1_scoretext.text = player1_score.ToString();
        checkscore();
    }

    public void  player2goal()
    {
        player2_score++;
        player2_scoretext.text = player2_score.ToString();
        checkscore();
    }

    private void checkscore()
    {
        if(player1_score == scoretoreach || player2_score == scoretoreach)
        {
            SceneManager.LoadScene(2);//if any of the player reaches the scoretoerach we'll load the gameover scene.
        }
    }
}
