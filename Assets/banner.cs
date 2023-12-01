
using UnityEngine;

public class banner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(ad), 3f);
    }
    public void ad()
    {
        AdsManager.instance?.ShowBanner();
    }
  
}
