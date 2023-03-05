using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public float xMinMax;
    public float zMin;
    public GameObject rock;
    public int count;
    public float StartWait;
    public float cloneWait;
    public float waveWait;

    public TextMeshProUGUI  scoreText;
    public TextMeshProUGUI  restartText;
    public TextMeshProUGUI  gameOverText;
    private int score;
    private bool restart;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameOver=restart=false;
        scoreText.text="Score : 0";
        restartText.text="Restart";
        gameOverText.text="";
        StartCoroutine(Waves());
    }

    void Update(){
        if(restart && Input.GetKeyDown(KeyCode.R)){
            Application.LoadLevel(Application.loadedLevel);
        }

    }

    // Update is called once per frame
    IEnumerator Waves() 
    {
        while(true)
        {
            yield return new WaitForSeconds(StartWait);
            for(int i = 0; i < count; i++)
            {
                Instantiate(rock, new Vector3(Random.Range(-xMinMax, xMinMax), 0, zMin), Quaternion.identity);
                yield return new WaitForSeconds(cloneWait);
            }
            if(gameOver){
                restart = true;
                restartText.text="Press E to restart";
                break;
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void addScore(int sc){
        score += sc;
        scoreText.text="Score "+ score;
    }

    public void GameOver(){
        gameOverText.text="Game over";
        gameOver=true;
    }
}
