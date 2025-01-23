using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogueData", menuName = "Dialogue/DialogueData")]
public class DialogueData : ScriptableObject {
    [System.Serializable]
    public class DialogueLine {
        public string speakerName;
        public string dialogueText;
        public Sprite backgroundImage; // Background image for the dialogue
        public bool triggerCameraShake; // Flag to trigger camera shake for this line
    }

    [System.Serializable]
    public class Scene {
        public string sceneName; // Name of the scene
        public DialogueLine[] dialogueLines; // Array of dialogue lines for this scene
    }

    public Scene[] scenes; // Array of scenes in this dialogue data
}
