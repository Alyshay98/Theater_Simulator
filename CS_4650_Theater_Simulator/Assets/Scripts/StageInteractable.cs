/*

Can be added to objects like Audio Sources in order to activate them. This is pretty simple at the
moment and is very subject to change.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInteractable : MonoBehaviour
{
    // The types of Interactables. List will likely grow.
    // 
    //  NONE:
    //      Does nothuing when activated.
    // 
    //  LIGHT:
    //      Activates a visible light on a stage prop. May be unnecessary, and even if it's not, it'll
    //      probably end up handled by StageToggle instead.
    // 
    //  SOUND:
    //      Activates a sound object, playing a sound.
    public enum InteractTypes {
        NONE = 0,
        LIGHT = 1,
        SOUND = 2
    }

    // The type of Interactable. This determines what exactly is done once the object is activated.
    public InteractTypes interactType = InteractTypes.NONE;

    public void Activate(){
        switch (interactType){
            case InteractTypes.NONE:
                break;
            case InteractTypes.LIGHT:
                break;
            case InteractTypes.SOUND:
                // I haven't actually tested if this works, but even if it doesn't, it should be a
                // simple fix.
                // GetComponent<AudioSource>().Play();

                print("(sound played)");
                break;
        }
    }
}
