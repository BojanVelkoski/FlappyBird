using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public Player player;
    private int score;
    public Text scoreText;
    public GameObject button;
    public GameObject gameOver;

    private void Awake(){
        Pause();
    }
    public void Play(){
        score=0;
        scoreText.text=score.ToString();
        button.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale=1f;
        player.enabled=true;

        PipeMovement[] pipes=FindObjectsOfType<PipeMovement>(); 
        for(int i=0;i<pipes.Length;i++){
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause(){
        Time.timeScale=0f;
        player.enabled=false;
    }
    public void increaseScore(){
        score++;
        scoreText.text=score.ToString();
    }

    public void GameOver(){
        gameOver.SetActive(true);
        button.SetActive(true);

        Pause();
    }
}
