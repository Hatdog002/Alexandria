using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class ButtonMan : MonoBehaviour
{
    /*
    private KeywordRecognizer keyword;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();


    public PuzzleManager manager;

    public TextMeshProUGUI textDialouge;
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("aligator", Disappear);
        actions.Add("book", Disappear1);
        actions.Add("car", Disappear2);
        actions.Add("dog", Disappear3);
        actions.Add("elephant", Disappear4);
        actions.Add("forest", Disappear5);
        actions.Add("gear", Disappear6);
        actions.Add("hand", Disappear7);
        actions.Add("insect", Disappear8);
        actions.Add("jar", Disappear9);
        actions.Add("kick", Disappear10);
        actions.Add("lion", Disappear11);
        actions.Add("moon", Disappear12);
        actions.Add("nail", Disappear13);
        actions.Add("ocean", Disappear14);
        actions.Add("person", Disappear15);
        actions.Add("queen", Disappear16);
        actions.Add("rock", Disappear17);
        actions.Add("stairs", Disappear18);
        actions.Add("table", Disappear19);
        actions.Add("underwear", Disappear20);
        actions.Add("vine", Disappear21);
        actions.Add("walk", Disappear22);
        actions.Add("xylophone", Disappear23);
        actions.Add("yell", Disappear24);
        actions.Add("zebra", Disappear25);

        keyword = new KeywordRecognizer(actions.Keys.ToArray());
        keyword.OnPhraseRecognized += Recognize;
    }
    public void buttonfunction()
    {
        textDialouge.text = "Ready to Speak";
        Invoke("clrMes", 1f);
        keyword.Start();
    }
    private void Recognize(PhraseRecognizedEventArgs speech)
    {
        string recognizedWord = speech.text.ToLower(); // Convert to lower case for case-insensitive matching
        if (actions.ContainsKey(recognizedWord))
        {
            actions[recognizedWord].Invoke();
        }
    }
    private void Disappear()
    {
        if (manager.words[0] == true)
        {
            Debug.Log("Apple");
            manager.wordsText[0].SetActive(false);
            manager.words[0] = true;
            manager.foundCounter++;
            keyword.Stop();
        }

    }
    private void Disappear1()
    {
        if (manager.words[1] == true)
        {
            Debug.Log("Book");
            manager.wordsText[1].SetActive(false);
            manager.words[1] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear2()
    {
        if (manager.words[2] == true)
        {
            Debug.Log("Car");
            manager.wordsText[2].SetActive(false);
            manager.words[2] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear3()
    {
        if (manager.words[3] == true)
        {
            Debug.Log("Car");
            manager.wordsText[3].SetActive(false);
            manager.words[3] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear4()
    {
        if (manager.words[4] == true)
        {
            Debug.Log("Car");
            manager.wordsText[4].SetActive(false);
            manager.words[4] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear5()
    {
        if (manager.words[5] == true)
        {
            Debug.Log("Car");
            manager.wordsText[5].SetActive(false);
            manager.words[5] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear6()
    {
        if (manager.words[6] == true)
        {
            Debug.Log("Car");
            manager.wordsText[6].SetActive(false);
            manager.words[6] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear7()
    {
        if (manager.words[7] == true)
        {
            Debug.Log("Car");
            manager.wordsText[7].SetActive(false);
            manager.words[7] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear8()
    {
        if (manager.words[8] == true)
        {
            Debug.Log("Car");
            manager.wordsText[8].SetActive(false);
            manager.words[8] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear9()
    {
        if (manager.words[9] == true)
        {
            Debug.Log("Car");
            manager.wordsText[9].SetActive(false);
            manager.words[9] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear10()
    {
        if (manager.words[10] == true)
        {
            Debug.Log("Car");
            manager.wordsText[10].SetActive(false);
            manager.words[10] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear11()
    {
        if (manager.words[11] == true)
        {
            Debug.Log("Car");
            manager.wordsText[11].SetActive(false);
            manager.words[11] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear12()
    {
        if (manager.words[12] == true)
        {
            Debug.Log("Car");
            manager.wordsText[12].SetActive(false);
            manager.words[12] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear13()
    {
        if (manager.words[13] == true)
        {
            Debug.Log("Car");
            manager.wordsText[13].SetActive(false);
            manager.words[13] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear14()
    {
        if (manager.words[14] == true)
        {
            Debug.Log("Car");
            manager.wordsText[14].SetActive(false);
            manager.words[14] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear15()
    {
        if (manager.words[15] == true)
        {
            Debug.Log("Car");
            manager.wordsText[15].SetActive(false);
            manager.words[15] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear16()
    {
        if (manager.words[16] == true)
        {
            Debug.Log("Car");
            manager.wordsText[16].SetActive(false);
            manager.words[16] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear17()
    {
        if (manager.words[17] == true)
        {
            Debug.Log("Car");
            manager.wordsText[17].SetActive(false);
            manager.words[17] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear18()
    {
        if (manager.words[18] == true)
        {
            Debug.Log("Car");
            manager.wordsText[18].SetActive(false);
            manager.words[18] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear19()
    {
        if (manager.words[19] == true)
        {
            Debug.Log("Car");
            manager.wordsText[19].SetActive(false);
            manager.words[19] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear20()
    {
        if (manager.words[20] == true)
        {
            Debug.Log("Car");
            manager.wordsText[20].SetActive(false);
            manager.words[20] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear21()
    {
        if (manager.words[21] == true)
        {
            Debug.Log("Car");
            manager.wordsText[21].SetActive(false);
            manager.words[21] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear22()
    {
        if (manager.words[22] == true)
        {
            Debug.Log("Car");
            manager.wordsText[22].SetActive(false);
            manager.words[22] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear23()
    {
        if (manager.words[23] == true)
        {
            Debug.Log("Car");
            manager.wordsText[23].SetActive(false);
            manager.words[23] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear24()
    {
        if (manager.words[24] == true)
        {
            Debug.Log("Car");
            manager.wordsText[24].SetActive(false);
            manager.words[24] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    private void Disappear25()
    {
        if (manager.words[25] == true)
        {
            Debug.Log("Car");
            manager.wordsText[25].SetActive(false);
            manager.words[25] = true;
            manager.foundCounter++;
            keyword.Stop();
        }
    }
    

    // Update is called once per frame
    void Update()
    {

    }

    void clrMes()
    {
        textDialouge.text = "";
    }
    */
}
