using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OfferWallScript : MonoBehaviour
{

    [SerializeField]
    private TMPro.TextMeshProUGUI Cointext;
     [SerializeField]
    private string Token = "YOUR_TOKEN";
    [SerializeField]
    private string UserId = "YOUR_USER_ID";

    public Animator offerwallAnimator;

    public GameObject popUpWindow;

    // Start is called before the first frame update
    void Start()
    {
        popUpWindow.SetActive(false);

        BitLabs.Init(Token, UserId);

        BitLabs.AddTag("userType", "new");
       

        BitLabs.SetRewardCallback(gameObject.name);

        Cointext.text = "0";

        
    }




    /// <summary>
    /// PopUp 
    /// </summary>

  
    public void OnPopup()
    {

        if (Cointext.text == "10000")
        {

            loading();
        }
        else
        {
            popUpWindow.SetActive(true);
            offerwallAnimator.SetTrigger("pop");

        }
    }




/// <summary>
/// Surveys
/// </summary>


    public void ShowSurveys()
    {
        BitLabs.LaunchOfferWall();
    }

    public void RewardCallback(string payout)
    {
       /// No backend server available
       /// Cointext.text = payout;
        Cointext.text = "10000";
        popUpWindow.SetActive(false);


    }




/// <summary>
/// UI
/// </summary>

    private void loading()
    {
        SceneManager.LoadScene("Level 200", LoadSceneMode.Single);
    }

    public void resetcoin()
    {
       Cointext.text = "0";
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void BacktoLevelSelect()
    {
     popUpWindow.SetActive(false);
    }

}
