/*****

Takes input in the form of strings to interact with the game world.

Strings can be input through the use of a textbox for now, but will
be updated to use the microphone.

Once a string is received, the StageEventController checks whether
the given string is associated with an EventData object. If it is,
the event activates.

To create a StageEventController, create an empty object in the
editor, give it an appropriate name (i.e. "Stage Event Controller").
then attach this script to the object as a component. Make sure to
fill the eventList with EventData objects in the editor.

*****/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StageEventController : MonoBehaviour
{
    public List<EventData> eventList;
    /*public*/ int currentEventIndex = 0;
    /*public*/ bool test_eventSucceeded = false;

    // List to check calls against to weed out nonsense input.
    // public List<string> test_validWords;
    
    // A list that determine which word is expected next, and if it expected at that exact moment.
    // Seems susceptible to failure, may find a different solution.
    // public List<string> test_orderOfExpectedWords;

    // (OBSOLETE)
    // The stage interactables that will be used in the scene. First, add the StageInteractable script as a component to a
    // sound or light object. Then, enter its name (MAKE SURE IT ALIGNS WITH THE FOLLOWING WORD LISTS: MIC, VALID, AND
    // ORDER OF EXPECTED). Finally, add the object to this list. When its name is input into InputStageCall(), the
    // StageInteractable will activate.
    // public List<StageInteractable> test_StageInteractables;

    // test variables
    // public LightCallController lightCallController;
    // int controlint = 0;
    // public NavMeshAgent navguy;

    // Start is called before the first frame update
    void Start()
    {
        // navguy.SetDestination(new Vector3(-4, 0, 0));
        // navguy.Move(new Vector3(1, 0, 0));

        StartCoroutine(RunStageScene()); // This coroutine will likely be started through player input in the future.
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    // Use string stageCall, which can be input from a textbox or microphone, to interact with the game's objects.
    public void InputStageCall(string stageCall){

        // Will need to check if the string aligns with available commands on a scene-by-scene basis.
        // Then, will need to check if the string aligns with the current expected string.
        
        // The reason for this is that if a word is given that has nothing to do with the scene, it can generally be ignored,
        // but if a REAL call is given at the wrong time, the crew may take action based on it. Therefore, mistakenly saying an
        // invalid word is less dangerous than mistakenly saying a valid word that is not expected.
        
        // test
        // print(stageCall);

        // change off of eventName eventually?
        // 
        // Currently only activates the expected event, when it should be able to activate any non-automatic event. (FIX NOW)
        if (!eventList[currentEventIndex].happensAutomatically && stageCall == eventList[currentEventIndex].eventName){
            // eventList[currentEventIndex].Activate();
            test_eventSucceeded = true;
        }

        // check word against valid words
        // if invalid, penalize and return

        // check word against current expectation
        // if invalid, penalize, make stage changes, inform actors to show confusion, return

        // if word is valid and expected, make stage changes, inform actors to proceed as normal
    }

    IEnumerator RunStageScene(){
        while (currentEventIndex < eventList.Count) {

            // wait for activationDelay seconds
            if (eventList[currentEventIndex].activationDelay > 0.0f){
                yield return new WaitForSeconds(eventList[currentEventIndex].activationDelay);
            }

            if (eventList[currentEventIndex].happensAutomatically){
                // run event
                eventList[currentEventIndex].Activate();
            } else {
                // yield for CORRECT event
                // this feels really wrong but if it works it works
                while(!test_eventSucceeded){
                    yield return null;
                }

                test_eventSucceeded = false;
                eventList[currentEventIndex].Activate();
            }

            currentEventIndex++;
        }
    }
}
