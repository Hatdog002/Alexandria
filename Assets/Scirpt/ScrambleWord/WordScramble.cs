using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Word
{
    public string word;
    [Header("Optional")]
    public string desiredRandom;

    public string GetString()
    {
        if (!string.IsNullOrEmpty(desiredRandom))
        {
            return desiredRandom;
        }

        string result = word;
        
        while (result == word)
        {
            result = "";
            List<char> characters = new List<char>(word.ToCharArray());
            while (characters.Count > 0)
            {
                int indexChar = Random.Range(0, characters.Count - 1);
                result += characters[indexChar];

                characters.RemoveAt(indexChar);
            }
        }
        
        return result;
    }
}
public class WordScramble : MonoBehaviour
{
    public Word[] words;

    [Header("UI")]
    public CharObject prefab;
    public Transform container;
    public float space;


    List<CharObject> charObjects = new List<CharObject>();

    CharObject firstSelected;

    public int currentWord;

    public static WordScramble Main;

    public bool correctanswer = false;

    public TextMeshProUGUI txtHint;

    public TextMeshProUGUI txtTutorial;

    public GameObject txtTutorialobj;

    public GameObject buttonHelp;
    private void Awake()
    {
        Main = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ///Show();
    }

    // Update is called once per frame
    void Update()
    {
        RepositionObject(); 
    }

    void RepositionObject()
    {
        if (charObjects.Count == 0)
        {
            return;
        }

        float center = 0f;
        if (charObjects.Count % 2 == 0) // Even number of objects
        {
            center = (charObjects.Count - 1) / 2f;
        }
        else // Odd number of objects
        {
            center = (charObjects.Count - 1) / 2f;
        }

        for (int i = 0; i < charObjects.Count; i++)
        {
            charObjects[i].rectTransform.anchoredPosition = new Vector2((i - center) * space, 0);
            charObjects[i].index = i;
        }
    }



    // Showrandom word to the screen
    public void ShowScramble()
    {
        ShowScramble(Random.Range(0, words.Length - 1));
    }

    // Show word from collection with desired index
    public void ShowScramble(int index)
    {
        charObjects.Clear();
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        if (index > words.Length -1)
        {
            Debug.Log("Index Out of range" + (words.Length - 1).ToString());
            return;
        }

        char[] chars = words[index].GetString().ToCharArray();
        foreach (char c in chars)
        {
            CharObject clone = Instantiate(prefab.gameObject).GetComponent<CharObject>();
            clone.transform.SetParent(container);

            charObjects.Add(clone.Init(c));
        }

        currentWord = index;
    }

    public void Swap(int indexA, int indexB)
    {
        CharObject tmpA = charObjects[indexA];

        charObjects[indexA] = charObjects[indexB];
        charObjects[indexB] = tmpA;

        charObjects[indexA].transform.SetAsLastSibling();
        charObjects[indexB].transform.SetAsLastSibling();

        CheckWord();
    }

    public void Select(CharObject charObject)
    {
        if (firstSelected)
        {
            Swap(firstSelected.index,charObject.index);

            //Unselect
            firstSelected.Select();
            charObject.Select();

        }
        else
        {
            firstSelected = charObject;
        }
    }
    
    public void UnSelect()
    {
        firstSelected = null;
    }

    public bool CheckWord()
    {
        string word = "";
        foreach(CharObject charObject in charObjects)
        {
            word += charObject.character;
        }
        if(word == words[currentWord].word)
        {
            //currentWord++;
            //ShowScramble(currentWord);
            correctanswer = true;
           
            Debug.Log("Done");

            return true;
        }

        return false;
    }

    public void ShowHint()
    {
        if (currentWord == 0)
        {
            // Code to execute if the condition is true
            txtHint.text = "A place where you can read books quitely";
        }
    }

    public void tutorial()
    {
        txtTutorial.text = "Welcome to your first hint";

        Invoke("text2", 3f);
        Invoke("text3", 6f);
        Invoke("text4", 9f);
        Invoke("Show", 12f);
    }
    void text2()
    {
        txtTutorial.text = "To obtain a hint you need to solve the jumbled word";
    }

    void text3()
    {
        txtTutorial.text = "To solve the hint, press the letter you want to move";
    }
    void text4()
    {
        txtTutorial.text = " After pressing the letter you want, press the other letter you want to swap it with.";
    }

    public void Show()
    {
        buttonHelp.gameObject.SetActive(true);
        txtTutorialobj.gameObject.SetActive(false);
        ShowScramble(currentWord);
        ShowHint();
    }
}
