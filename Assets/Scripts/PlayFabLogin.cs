using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    [Header("LOGIN")]
    private string userEmailLogin;
    private string userPasswordLogin;

    public void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "F0BE7";
        }

        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPasswordLogin };
        
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first succesful API call!");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :" +
            "¨(");

        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
    public void GetUserPasswordLogin(string passwordIn)
    {
        userPasswordLogin = passwordIn;
    }

    public void GetUserEmailLogin(string emailIn)
    {
        userEmailLogin = emailIn;
    }
    public void LogIn()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPasswordLogin };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
}
