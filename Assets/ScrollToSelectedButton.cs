using UnityEngine;
using UnityEngine.UI;

public class ScrollToSelectedButton : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Button targetButton;
    public Button[] levelbutton;
    private void Start()
    {
        int _lockLevel = PlayerPrefs.GetInt("Currentlevel", 1);
        targetButton = levelbutton[_lockLevel];
        // Call this method to scroll to the target button when needed
        ScrollToTargetButton();
    }
    void OnEnable()
    {
        int _lockLevel = PlayerPrefs.GetInt("Currentlevel",1);
        targetButton = levelbutton[_lockLevel ];
        // Call this method to scroll to the target button when needed
        ScrollToTargetButton();
    }

    void ScrollToTargetButton()
    {
        // Check if both the scrollRect and targetButton are assigned
        if (scrollRect != null && targetButton != null)
        {
            // Get the RectTransform of the content within the ScrollRect
            RectTransform contentRectTransform = scrollRect.content;

            // Calculate the normalized position of the target button within the scroll view
            float normalizedPosition = CalculateNormalizedPosition(contentRectTransform, targetButton);

            // Set the normalized position to scroll to the target button
            scrollRect.normalizedPosition = new Vector2(scrollRect.normalizedPosition.x, normalizedPosition);
        }
        else
        {
            Debug.LogError("Please assign the ScrollRect and Target Button in the inspector!");
        }
    }

    float CalculateNormalizedPosition(RectTransform content, Button target)
    {
        // Get the index of the target button within the content
        int targetIndex = target.transform.GetSiblingIndex();

        // Calculate the normalized position based on the index and total buttons
        float normalizedPosition = 1f - (float)targetIndex / (content.childCount - 1);

        // Clamp the value to be between 0 and 1
        normalizedPosition = Mathf.Clamp01(normalizedPosition);

        return normalizedPosition;
    }
}
