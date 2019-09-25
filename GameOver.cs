using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*INCOMPLETE*/
public class GameOver : MonoBehaviour
{
    
    public string levelName; //name of the level in the scene manager

    private boolean gameOver;

    void Start(){
        gameOver = false;
    }

    void Update(){
        gameOverRoutine();
        if(verifiyEndGame()){
            //the while loop allows to wait for the player to choose to restart the level
            while(gameOver){
                if(Input.GetMouseButton(0)){
                    restart();
                }
                //NOTE: consider another scenario
                //such as a button to go back to the main menu
            }
        }

    }

    public boolean verifyEndGame(){
        //function to check if the player has lost
        if(failCondition){
            gameOver = true;
        }
        else{
            //unnecessary except for good practice
            gameOver = false;
        }
        return gameOver;
    }

    private void restart(){
        //function to restart the level after losing
        gameOver = false;
        SceneManager.LoadScene(levelName);
    }

    private gameOverRoutine(){
        //function to do what you need to do in case of game over
    }

}