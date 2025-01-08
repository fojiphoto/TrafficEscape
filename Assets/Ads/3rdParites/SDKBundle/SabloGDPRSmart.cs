//using TapticPlugin;
using UnityEngine;

public class SabloGDPRSmart : MonoBehaviour
{
    [SerializeField] private GameObject agreeTermsPanel;
    [SerializeField] private GameObject dontAgreeTermsPanel;
    [SerializeField] private GameObject dontAgreeAndroid;


    private void Start()
    {
        if(!agreeTermsPanel.activeSelf)
            agreeTermsPanel.SetActive(true);
        
        if(dontAgreeTermsPanel.activeSelf)
            dontAgreeTermsPanel.SetActive(false);
        
                
        if(dontAgreeAndroid.activeSelf)
            dontAgreeAndroid.SetActive(false);
    }

    public void AgreeToTermsPressed()
    {
        Debug.Log("GDPR accepted, lets run game");
        AdsManager.instance.GDPRPopupAccepted();
        //TapticManager.Impact(ImpactFeedback.Light);
        Time.timeScale = 1;
        Destroy(gameObject);
    }
    
    public void DontAgreeToTermsPressed()
    {
        Debug.Log("GDPR accepted, lets run game");
        agreeTermsPanel.SetActive(false);
        
#if UNITY_ANDROID
            dontAgreeAndroid.SetActive(true);
#else
        dontAgreeTermsPanel.SetActive(true);
#endif

    }
    
    public void OpenPrivacyLink()
    {
        Application.OpenURL("https://orbitgamesglobal-privacy-policy.blogspot.com/");
    }
}
