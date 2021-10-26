using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shooting : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject smoke;
    public Text text,Score,Highscoretext;
    public AudioSource audioSource;

    public GameObject Main, GameOver;

   // public DargonController DargonController;

    int score;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
       // DargonController = GameObject.Find("Bird 1").GetComponent<DargonController>();
    }
    public void Update()
    {
        text.text = "Score: " + score.ToString();
        Score.text = "Score: " + score.ToString();
        Highscoretext.text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();
        
    }
    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Chicken" || hit.transform.tag == "Dargon" || hit.transform.tag == "Condor")
            {
                
                if (hit.transform.tag == "Dargon")
                {
                    score += 5;
                }
                if (hit.transform.tag == "Chicken")
                {
                    score += 15;
                }
                if (hit.transform.tag == "Condor")
                {
                    score += 10;
                }
                Destroy(hit.transform.gameObject);
                //  AudioSource.PlayClipAtPoint(AudioSource.clip,Vector3.zero);
                audioSource.Play();
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }

        /*if(DargonController.selfkill == true)
        {
            score -= 5;
            DargonController.selfkill = false;
        }*/
       
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void HighScore()
    {

        Main.SetActive(false);
        GameOver.SetActive(true);
        if(score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        Time.timeScale = 0;

    }
}
