using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class Script : MonoBehaviour
{
    public bool _timerActive;
    public float _currentTime;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _stoptext;
    [SerializeField] private Button btn;
    public ParticleSystem ps;
    private int hours;
    [SerializeField] private TMP_Text hourstext;
   // private float firsttime;
    public GameObject Kanakona;
    public GameObject Hour;
   // private bool flag;
    private float movespeed;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        _currentTime = 0;
        _timerActive = false;
        _stoptext.text = "START";
        hourstext.text = "0";
        var emission = ps.emission;
        emission.rateOverTime= 0;
        //firsttime = 0;
      //  flag = false;
       // movespeed = 0.00005f;
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "HelpScene")
        {

            if (Input.GetKey(KeyCode.Space))
            {
                LoadStopWatch();
                StartStopwatch();
            }
        }
        if (_timerActive)
        {
            
            TimeSpan time = TimeSpan.FromSeconds(_currentTime);

            btn.onClick.AddListener(StopStopwatch);
            _currentTime+=Time.deltaTime;
            _text.text = time.Minutes.ToString()+":"+time.Seconds.ToString()+":"+time.Milliseconds.ToString();
            int x = Int32.Parse(hourstext.text);

            if (hourstext.text == "0")
            {
                Kanakona.SetActive(false);
            }
            else
            {
                Kanakona.SetActive(true);
            }
                
            hourstext.text = time.Hours.ToString();

            

        }

        if (!_timerActive)
        {
            btn.onClick.AddListener(StartStopwatch);
            
        }

        if (!_timerActive && Input.GetKey(KeyCode.Space) )
        {
            StartStopwatch();
        }
        if (_timerActive && Input.GetKeyDown(KeyCode.S))
        {
            StopStopwatch();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Exitted Successfully");
        }
        /**if (Input.GetKeyDown(KeyCode.Space) && !_timerActive)
        {
              StartStopwatch();
        }**/
        
        if (Input.GetKeyDown(KeyCode.R))
        {
              ResetStopWatch();
        }

    }
    public void LoadStopWatch()
    {
        SceneManager.LoadScene("SceneStop");
    }
    public void LoadMainScreen()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void LoadContactScreen()
    {
        SceneManager.LoadScene("ContactScene");

    }
    public void LoadHelpingScreen()
    {
        SceneManager.LoadScene("HelpScene");
    }
    public void StartStopwatch()
    {
        _timerActive = true;
        var emission = ps.emission;
        emission.rateOverTime = 2;
       
        _stoptext.text = "STOP";
    }
    public void StopStopwatch()
    {
        _timerActive = false;
        //particlesystem.SetActive(false);
        var emission = ps.emission;
        emission.rateOverTime = 0;
        
        _stoptext.text = "START";
    }
    public void ResetStopWatch()
    {
        _timerActive = false;
        _currentTime = 0;
        _text.text = "0:0:0";
    }
    public void backfunction()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void openGit()
    {
        Application.OpenURL("https://github.com/akashsr04");
    }
    public void openLinkedIn() 
    {

        Application.OpenURL("https://linkedin.com/in/akashsr04");
    }
    public void openInstagram()
    { 
        Application.OpenURL("https://instagram.com/akashsr04");
    }
}

// 1123.6 328.7
