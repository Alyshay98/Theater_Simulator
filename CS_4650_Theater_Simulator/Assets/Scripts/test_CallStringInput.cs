using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class test_CallStringInput : MonoBehaviour
{
    public StageEventController stageEventController;
    private TMP_InputField callStringInput;

    // Start is called before the first frame update
    void Start()
    {
        callStringInput = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Once a string is entered and the submit button is pressed, send the string to the
    // Stage Event Controller, which will take action depending on what was entered.
    public void submitCallString(){
        stageEventController.InputStageCall(callStringInput.text);
    }
}
