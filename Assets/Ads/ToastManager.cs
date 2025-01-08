using UnityEngine;
using TMPro;  // Import TextMeshPro
using DG.Tweening;  // Import DoTween for animations

public class ToastManager : MonoBehaviour
{
    public static ToastManager Instance { get; private set; }  // Singleton Instance

    [SerializeField] private TextMeshProUGUI textMessage;  // TextMeshPro Field for Message Display
    [SerializeField] private CanvasGroup canvasGroup;  // Used for fading in/out if necessary
    [SerializeField] private RectTransform messageRect;  // RectTransform for Sliding Animations

    private float defaultDisplayTime = 2f;  // Default time message stays on screen

    // Enum to handle different message types
    public enum MessageType
    {
        Simple,    // Green for regular messages
        Warning,   // Yellow for warnings
        Error      // Red for error messages
    }

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Optional, keeps the manager across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        // Ensure canvas group is set to invisible at the start
        canvasGroup.alpha = 0f;
    }

    /// <summary>
    /// Displays a toast message with a slide-in and slide-out animation.
    /// </summary>
    /// <param name="message">Message to display.</param>
    /// <param name="messageType">Type of message to display (Simple, Warning, Error).</param>
    /// <param name="displayTime">Customizable time to display the message (optional).</param>
    public void ShowToast(string message, MessageType messageType, float displayTime = -1f)
    {
        // Set the message text
        textMessage.text = message;

        // Set the color based on the message type
        switch (messageType)
        {
            case MessageType.Simple:
                textMessage.color = Color.green;  // Green for simple messages
                break;
            case MessageType.Warning:
                textMessage.color = Color.yellow;  // Yellow for warnings
                break;
            case MessageType.Error:
                textMessage.color = Color.red;  // Red for error messages
                break;
        }

        // If no custom display time is given, use the default
        float timeToDisplay = displayTime > 0 ? displayTime : defaultDisplayTime;

        // Reset position for sliding animation (from below the screen)
        messageRect.anchoredPosition = new Vector2(0, -Screen.height / 2);  // Start from below the screen

        // Sequence to handle slide-in, stay, and slide-out using DoTween
        Sequence toastSequence = DOTween.Sequence();

        // Slide in (move from bottom to center)
        toastSequence.Append(messageRect.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.OutCubic));  // Slide to center in 0.5s

        // Fade in
        toastSequence.Insert(0f, canvasGroup.DOFade(1f, 0.5f));  // Fade in

        // Wait for the display time
        toastSequence.AppendInterval(timeToDisplay);

        // Slide out (move down out of screen)
        toastSequence.Append(messageRect.DOAnchorPos(new Vector2(0, -Screen.height / 2), 0.5f).SetEase(Ease.InCubic));  // Slide down in 0.5s

        // Fade out
        toastSequence.Insert(timeToDisplay + 0.5f, canvasGroup.DOFade(0f, 0.5f));  // Fade out

        // Start the sequence
        toastSequence.Play();
    }

    /// <summary>
    /// Change the default display time for the toast messages.
    /// </summary>
    /// <param name="newDisplayTime">New default time for the toast message to be displayed.</param>
    public void SetDefaultDisplayTime(float newDisplayTime)
    {
        defaultDisplayTime = newDisplayTime;
    }
}
