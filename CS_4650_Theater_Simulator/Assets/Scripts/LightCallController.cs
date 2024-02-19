// Deprecated. Will delete, or will add "test_" as a prefix before this script's name.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCallController : MonoBehaviour
{
    public List<LightPreset> lightPresets;

    public void Activate(int index){
        // TEST
        lightPresets[index].ApplyChanges();


    }
}
