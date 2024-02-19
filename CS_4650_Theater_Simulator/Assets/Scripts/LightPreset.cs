/*

Stores several LightData objects to be simultaneously activated by a call.

To setup:

Create an empty object, attach this script to it as a component, then add any
LightData objects to the lightDataList using the editor.

For organization, you could make all LightPresets be children of a dedicated
empty object specifically for containing LightPresets. Alternatively, you
could add LightPresets as children of the EventData they fall under. However,
I plan to change how EventData works in relation to LightPresets, so maybe
hold off on that.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPreset : MonoBehaviour
{
    public List<LightData> lightDataList;

    public void ApplyChanges(){
        for (int i = 0; i < lightDataList.Count; i++){
            lightDataList[i].ApplyChanges();
            // print("applied changes");
        }
    }
}
