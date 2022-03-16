using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI goldText;

    public int CurrentBalance 
    {
        get 
        {
            return currentBalance;
        }
    }

    void Awake()
    {
        currentBalance = startingBalance;
        DisplayBalance();
    }
   
   public void Deposit(int amount)
   {
       currentBalance += Mathf.Abs(amount);
       DisplayBalance();
   }

   public void WithDraw(int amount)
   {
       currentBalance -= Mathf.Abs(amount);
       DisplayBalance();

       if(currentBalance < 0)
       {
           //lose game
           ReloadScene();
       }
   }

    void DisplayBalance()
    {
         goldText.text = "Gold: " + currentBalance.ToString();
    }
    
   void ReloadScene()
   {
       Scene currentScene = SceneManager.GetActiveScene();
       SceneManager.LoadScene(currentScene.buildIndex);
   }
}
