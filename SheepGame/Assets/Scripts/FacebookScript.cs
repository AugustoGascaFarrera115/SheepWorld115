using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FacebookScript : MonoBehaviour
{


    public Text FriendsText;


    private void Awake()
    {
        if(!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    Debug.Log("Couldnt Initialized");
            },isGameShow =>
            {
                if(!isGameShow)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            });
        }
        else
        {
            FB.ActivateApp();
        }
    }


    #region Login/Logout
    public void FacebookLogin()
    {
        var permissions = new List<string>()
        {
            "public_profile","email","user_friends"
        };

        FB.LogInWithReadPermissions(permissions);
    }

    public void FacebookLogout()
    {
        FB.LogOut();
    }

    #endregion


    public void FacebookShare()
    {
        FB.ShareLink(new System.Uri("http://resocoder.com"), "Check It Out !", "Good programming tutorials !");
    }



    #region Inviting


    public void FacebookGameRequest()
    {
        FB.AppRequest("Hey come to play this awesome game",title:"APP with Facebook SDK");
    }

    /*public void FacebookInvite()
    {
        FB.Mobile.AppInvite();
    } */

    #endregion


    public void GetFriendsPlayingThisGame()
    {
        string query = "/me/friends";

        FB.API(query, HttpMethod.GET, result =>
          {
              var dictionary = (Dictionary<string, object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);
              var friendsList = (List<object>)dictionary["data"];

              FriendsText.text = string.Empty;

              foreach(var dict in friendsList )
              {
                  FriendsText.text += ((Dictionary<string, object>)dict)["name"];
              }
          });
    }

}
