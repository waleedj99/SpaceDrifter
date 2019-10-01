using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SceneController : MonoBehaviour
{
    
    public bool GrabberOn;
    public static float fuelMultiplier;
    public GameObject grabber;
    public Camera mainCamera;
    Canvas TriggerCanvas,GameWinCanvas;
    TextMeshProUGUI scoreText,winScoreText,multiplierText;
    public bool playerOnTrigger;
    ShipRes shipRes;
    public bool isPause=false;
   Canvas gameOverPanel;
       Text shipFuel,shipFood;
    // Start is called before the first frame update
    void Start()
    {
        multiplierText = GameObject.Find("multiplierText").GetComponent<TextMeshProUGUI>();
        GameWinCanvas = GameObject.Find("GameWon").GetComponent<Canvas>();
        winScoreText = GameObject.Find("WinScore").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        gameOverPanel = GameObject.Find("GameOver").GetComponent<Canvas>();
        shipFood = GameObject.Find("ShipFood").GetComponent<Text>();
        shipFuel = GameObject.Find("ShipFuel").GetComponent<Text>();
        shipRes = GameObject.Find("Ship").GetComponent<ShipRes>();
    }

    // Update is called once per frame
    void Update()
    {
        multiplierText.text = "- x" + fuelMultiplier;
        if(isPause){
            Time.timeScale=0;
            var score = (int)shipRes.fuel + (int)shipRes.food + GameObject.FindGameObjectsWithTag("crew").Length * 100;
            if(!shipRes.isWon){
                scoreText.text = "Score:"+score ;
                gameOverPanel.enabled = true;
            }else{
                winScoreText.text = "Score:" + score;
                GameWinCanvas.enabled = true;
            }
        }else
        {
            gameOverPanel.enabled = false;
            Time.timeScale=1;
        }
        
            if(playerOnTrigger&&!GrabberOn){
                GameObject.Find("CanvasTrigger").GetComponent<Canvas>().enabled = true;
                
            }else
            {
                GameObject.Find("CanvasTrigger").GetComponent<Canvas>().enabled = false;
            }
        
        if(GrabberOn){
            grabber.SetActive(true);
            GameObject.Find("CanvasOnGrab").GetComponent<Canvas>().enabled = true;
        }else
        {
            grabber.SetActive(false);
            GameObject.Find("CanvasOnGrab").GetComponent<Canvas>().enabled = false;
        }
        //UI STUFF
        // shipFood.text  = ""+shipRes.food;
        
        // shipFuel.text = ""+shipRes.fuel;
        //UI STUFF
        if(Input.GetKeyDown(KeyCode.Space)){
            GrabberOn = !GrabberOn;
        }
        if(GrabberOn){
            mainCamera.orthographicSize = 40;
            mainCamera.gameObject.GetComponent<Transform>().position = new Vector3(
                mainCamera.gameObject.GetComponent<Transform>().position.x
                ,mainCamera.gameObject.GetComponent<Transform>().position.y,-10);
            GameObject.Find("Ship").GetComponent<EdgeCollider2D>().enabled = false;
            GameObject.Find("ShipTop").GetComponent<EdgeCollider2D>().enabled = true;
        }else{
            mainCamera.orthographicSize = 24;
            mainCamera.gameObject.GetComponent<Transform>().position = new Vector3(
               mainCamera.gameObject.GetComponent<Transform>().position.x
               , mainCamera.gameObject.GetComponent<Transform>().position.y, -1);
            GameObject.Find("ShipTop").GetComponent<EdgeCollider2D>().enabled = false;
            GameObject.Find("Ship").GetComponent<EdgeCollider2D>().enabled = true;
        }
    }
}
