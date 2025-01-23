using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {
    public DialogueData dialogueData; // Reference to your DialogueData
    public TextMeshProUGUI dialogueText; // UI Text component for displaying dialogue
    public TextMeshProUGUI speakerName; // UI Text component for displaying dialogue
    public Image backgroundImage; // UI Image component for displaying the background image
    public Button nextButton; // Button to go to the next dialogue line

    public RectTransform uiElementToShake; // Reference to the UI element to shake (e.g., canvas or dialogue box)

    public float shakeDuration = 0.5f; // Duration of the shake
    public float shakeMagnitude = 20f; // Magnitude of the shake in pixels

    private Vector3 originalUIPosition; // To store the original UI position

    private int currentSceneIndex = 0; // Index of the current scene
    private int currentLineIndex = 0; // Index of the current dialogue line

    public string nextscene;

    public AudioScene scence;
    void Start() {
        // Initialize the first dialogue line display
        DisplayCurrentLine();
        nextButton.onClick.AddListener(NextLine);

        // Store the original UI position
        if (uiElementToShake != null) {
            originalUIPosition = uiElementToShake.anchoredPosition;
        }
    }

    void DisplayCurrentLine() {
        if (currentSceneIndex < dialogueData.scenes.Length) {
            var scene = dialogueData.scenes[currentSceneIndex];

            if (currentLineIndex < scene.dialogueLines.Length) {
                var line = scene.dialogueLines[currentLineIndex];
                speakerName.text = line.speakerName;
                dialogueText.text = line.dialogueText;

                // Only update the image if there is a new image
                if (line.backgroundImage != null) {
                    backgroundImage.sprite = line.backgroundImage; // Set the image if it exists
                }

                // Check if camera shake should be triggered
                if (line.triggerCameraShake) {
                    StartCoroutine(UIShake());
                }
            }
            else {
                currentSceneIndex++;
                currentLineIndex = 0;
                DisplayCurrentLine(); // Display the first line of the next scene
            }
        }
        else {
            // Optionally handle when all scenes are done
            // nextButton.interactable = false; // Disable the button
           
            SceneManager.LoadScene(nextscene);
        }
    }

    void NextLine() {
        currentLineIndex++; // Move to the next line
        DisplayCurrentLine(); // Update the display
    }

    // Coroutine for shaking the UI element
    IEnumerator UIShake() {
        float elapsed = 0f;

        while (elapsed < shakeDuration) {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            uiElementToShake.anchoredPosition = new Vector2(originalUIPosition.x + x, originalUIPosition.y + y);

            elapsed += Time.deltaTime;

            yield return null;
        }

        // Reset UI position
        uiElementToShake.anchoredPosition = originalUIPosition;
    }
}
