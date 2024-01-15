using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.UI;


public class Eventsystem : MonoBehaviour
{


    #region Player Data 
    // ---------------------------  PlayerData -------------------------
    private PlayerData playerData;

    public GameObject playerLevelObj;
    public GameObject streakObj;
    public GameObject streakSymbolObj;
    public GameObject rankObj;
    public GameObject trainingTimeObj;
    public GameObject traingNameObj;
    public GameObject traingGoalObj;

    public Texture streak_on;
    public Texture streak_off;

    private TextMeshProUGUI playerLevelTxt;
    private TextMeshProUGUI streakTxt;
    private TextMeshProUGUI rankTxt;
    private TextMeshProUGUI trainingTimeTxt;
    private TextMeshProUGUI traingNameTxt;
    private TextMeshProUGUI traingGoalTxt;

    private Workoutmanagment workoutmanagment;
    #endregion


    public int streak = 0;
    public string rank = "A";
    public int levelExc1 = 0;
    public int levelExc2 = 0;
    public int levelExc3 = 0;
    public int levelExc4 = 0;
    public int levelExc5 = 0;

    private RawImage streakImage;


    public int trainingTime = 0;
    public string[] traingName = new string[] { "Situp", "Jumping Jacks", "Plank","Situp", "Squat" }; 
    public int traingGoal = 0;


    // ------------------- Level Bar ---------------------------
    public int playerLevel = 0;
    public float xp = 0;
    public GameObject sliderObj;
    private Slider slider;
    private float targetValue;
    private float fillSpeed = 10;


    //-------------------- Navigation -----------------------------

    public GameObject homeTAB;
    public GameObject profileTAB;
    public GameObject workoutChoosePanel;
    public GameObject workoutPanel;
    public GameObject workout1Panel;
    public GameObject workout2Panel;
    public GameObject workout3Panel;
    public GameObject workout4Panel;
    public GameObject workout5Panel;




    private void Awake()
    {
        slider = sliderObj.GetComponent<Slider>();

        playerLevelTxt = playerLevelObj.GetComponent<TextMeshProUGUI>();

        streakTxt = streakObj.GetComponent<TextMeshProUGUI>();
        rankTxt = rankObj.GetComponent<TextMeshProUGUI>();
        trainingTimeTxt = trainingTimeObj.GetComponent<TextMeshProUGUI>();
        traingNameTxt = traingNameObj.GetComponent<TextMeshProUGUI>();
        traingGoalTxt = traingGoalObj.GetComponent<TextMeshProUGUI>();


        streakImage = streakSymbolObj.GetComponent<RawImage>();



     

    }


    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        refreshDisplay();



        if (slider.value < targetValue)
        {
            slider.value += fillSpeed * Time.deltaTime;

        }




    }

   


    public void reloadStats()
    {
        playerData = PlayerData.Instance;

        playerLevel = playerData.playerLevel;
        xp = playerData.xp;
        streak = playerData.streak;
        rank = playerData.rank;
        levelExc1 = playerData.levelExc1;
        levelExc2 = playerData.levelExc2;
        levelExc3 = playerData.levelExc3;
        levelExc4 = playerData.levelExc4;
        levelExc5 = playerData.levelExc5;

    }

    public void refreshDisplay()
    {
        reloadStats();
        playerLevelTxt.text = playerLevel.ToString();
        setXP(xp);
        streakTxt.text = streak.ToString();
        rankTxt.text = rank;
        checkStreak();


    }






    //---------------- Level Bar Code ------------------

    public void addXP(float newXP)
    {
        targetValue = slider.value + newXP;
    }

    public void setXP(float newXP)
    {
        slider.value = newXP;
    }


    // --------------- Streak Code ----------------------


    private void checkStreak()
    {

        if (playerData.streak < 1)
        {
            streakImage.texture = (Texture)streak_off;
        }
        else
        {
            streakImage.texture = (Texture)streak_on;
        }
    }





    // -------------- Navigation -------------------------

    /*
     * 0 Home Tab
     * 1 Profile
     * 2 Workout Menu
     * 3 Inside Workout
     * 
     */

    public void navigateTo(int choose)
    {
        switch (choose)
        {
            case 0:
                homeTAB.SetActive(true);
                profileTAB.SetActive(false);
                workoutChoosePanel.SetActive(false);
                workoutPanel.SetActive(false);
                break;
            
            case 1:
                homeTAB.SetActive(false);
                profileTAB.SetActive(true);
                workoutChoosePanel.SetActive(false);
                workoutPanel.SetActive(false);
                break;
            
            case 2:
                homeTAB.SetActive(false);
                profileTAB.SetActive(false);
                workoutChoosePanel.SetActive(true);
                workoutPanel.SetActive(false);
                break;
        
            case 3:
            homeTAB.SetActive(false);
            profileTAB.SetActive(false);
            workoutChoosePanel.SetActive(false);
            workoutPanel.SetActive(true);
            break;

        }
      
    }

    
    
    /*
     * 1 Push Up
     * 2 Jumping Jacks
     * 3 Plank
     * 4 Situp
     * 5 Squat
     */

    public void navigateWorkout(int choose)
    {

        switch (choose)
        {
            case 1:
                workout1Panel.SetActive(true);
                workout2Panel.SetActive(false);
                workout3Panel.SetActive(false);
                workout4Panel.SetActive(false);
                workout5Panel.SetActive(false);
                workoutmanagment.setWorkout(1);
                break;
                

            case 2:
                workout1Panel.SetActive(false);
                workout2Panel.SetActive(true);
                workout3Panel.SetActive(false);
                workout4Panel.SetActive(false);
                workout5Panel.SetActive(false);
                workoutmanagment.setWorkout(2);
                break;


            case 3:
                workout1Panel.SetActive(false);
                workout2Panel.SetActive(false);
                workout3Panel.SetActive(true);
                workout4Panel.SetActive(false);
                workout5Panel.SetActive(false);
                workoutmanagment.setWorkout(3);
                break;

            case 4:
                workout1Panel.SetActive(false);
                workout2Panel.SetActive(false);
                workout3Panel.SetActive(false);
                workout4Panel.SetActive(true);
                workout5Panel.SetActive(false);
                workoutmanagment.setWorkout(4);
                break;

            case 5:
                workout1Panel.SetActive(false);
                workout2Panel.SetActive(false);
                workout3Panel.SetActive(false);
                workout4Panel.SetActive(false);
                workout5Panel.SetActive(true);
                workoutmanagment.setWorkout(5);
                break;

           

        }

        this.navigateTo(3);

    }



}
