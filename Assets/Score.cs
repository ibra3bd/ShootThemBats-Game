using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int current_score;
    public TextMeshProUGUI score;
    [SerializeField] Animator[] Hearts;
    int lastIndex = 0;
    public static bool bat_flew;
   
    // Start is called before the first frame update
    void Start()
    {
        current_score = 0;
        bat_flew = false;
    }

    // Update is called once per frame
     private void Update()
    {

       
        //for checking if it's time for the bat to fly away
        if (bat_flew)
        {
            Remove_Heart();
            bat_flew=false;
        }

        score.text = "Score: " + current_score.ToString();
    }




    public void Remove_Heart()
    {
        if (lastIndex <= Hearts.Length - 1)
        {
            Hearts[lastIndex].SetTrigger("Lost" + lastIndex);
            lastIndex++;
           
        }

    }



}

