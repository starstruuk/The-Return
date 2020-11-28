using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Player player;

    public InputField textEntryField;
    public Text logText;
    public Text currentText;

    public Actions[] actions;
    [TextArea]
    public string introText;
    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLocation(bool additive = false)
    {
        string description = player.playerLocation.description + "\n";
        description+= player.playerLocation.GetDirections();
        description+=player.playerLocation.GetItems();
        if (additive)
            currentText.text += "\n" + description;
        else
            currentText.text = description;
    }

    public void DisplayText()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    public void LogCurrentText()
    {
        logText.text += "\n";
        logText.text += currentText.text;

        logText.text += "\n";
        logText.text += "<color=000000ff>"+textEntryField.text+"</color>";
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = {' '};
        string[] separateWords = input.Split(delimiter);

        foreach (Actions action in actions)
        {
            if (action.keyword == separateWords[0])
            {
                if (separateWords.Length>1)
                {
                    action.RespondToInput(this, separateWords[1]);
                }

                else{
                    action.RespondToInput(this, "");
                }

                return;
            }

        }

        //exit case
        currentText.text = "Nothing happened...(have you tried typing 'Help'?)";
    }
}
