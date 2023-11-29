using UnityEngine;
using TMPro;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;

public class playGamesManager : MonoBehaviour
{
    private void Start()
    {
        SignIn();
    }

    public void SignIn()
    {
        //PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    //internal void ProcessAuthentication(SignInStatus status)
    //{
    //    if (status == SignInStatus.Success)
    //    {
    //        string name = PlayGamesPlatform.Instance.GetUserDisplayName();
    //        string id = PlayGamesPlatform.Instance.GetUserId();
    //        string imgURL = PlayGamesPlatform.Instance.GetUserImageUrl();
    //    }

    //    else
    //    {

    //    }
    //}
}
