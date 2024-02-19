/*

Holds data for ONE light source object in the scene. Several of these will be
stored in LightPreset objects, which are called by the player when lighting
changes are needed.

To setup:

Create an empty object and attach this script to it as a component. Assign the
lightObject, adjust the settings until it will yield the desired result, then
add this LightData object to a unique LightPreset's lightDataList through the
editor.

For organization in the editor scene hierarchy, try to have LightData objects
be children of the LightPreset they're attached to.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightData : MonoBehaviour
{
    // The specific light object
    public Light lightObject;

    // Set whether the light will be active or not. 
    public bool lightTurnedOn = true;
    
    // The amount of time it takes for lighting changes to go into effect.
    public int fadeSeconds = 2;

    // The color that the light will change to. If you want to leave the color as-is, set changeColor to false.
    public bool changeColor = true;
    public Color newColor = Color.white;

    // The intensity (or brightness) that the light will change to. If you want to leave the intensity as is, set changeIntensity to false.
    public bool changeIntensity = false;
    public float newIntensity = 1.0f;

    // Over the course of "fadeSeconds" seconds, change the light's data to the data stored in this preset.
    // (if the light will turn off, change intensity to 0 over the course of the seconds.)
    // (if the light will turn on, change intensity to 0 immediately, activate light, change intensity to "intensity" over the course of the seconds.)
    // 
    // Should probably make it so that running this while there are coroutines executing on an object already stops those coroutines. not sure how i would do that though.
    // For now I just gotta be careful to not allow these things to go too quickly. Chances are they won't ever, but like, good to be safe.
    public void ApplyChanges(){
        // print("lightTurnedOn: " + lightTurnedOn + "\nfadeSeconds: " + fadeSeconds + "\nchangeColor: " + changeColor + "\n")

        if (changeColor){
            // print("got into changeColor");
            // start coroutine
            StartCoroutine(ApplyColorChange(lightObject.color, newColor));
        }

        // if the light is turning off, there's no need to change the intensity. this is not entirely true, as if the light turns back on, you'd want it
        // to be the intensity you set it to before.
        // 
        // the logic:
        //  - if the light is turning on:
        //    - if change intensity: change from 0 to the intensity given
        //    - if no change intensity: change from 0 to lightObject's current intensity (store this value before setting to 0)
        //  - if the light is turning off:
        //    - change from current to 0 (if change intensity, change the light's intensity after it's been deactivated)
        //  - if the light is already on:
        //    - if change intensity: change from current value to the intensity given
        if ((lightTurnedOn && !lightObject.enabled) || (changeIntensity && lightTurnedOn)) { // could technically combine these cases but it complains at me
            // print("got into lightTurnedOn");
            float targetVal;
            
            if (changeIntensity) { targetVal = newIntensity; }
            else { targetVal = lightObject.intensity; }

            if (!lightObject.enabled){
                lightObject.intensity = 0.0f;
                lightObject.enabled = true;
            }

            float startVal = lightObject.intensity;


            // coroutine
            StartCoroutine(ApplyIntensityChange(startVal, targetVal, false));
        } else if (!lightTurnedOn && lightObject.enabled){
            // print("turning off light");
            StartCoroutine(ApplyIntensityChange(lightObject.intensity, 0.0f, true));
        }
    }

    IEnumerator ApplyColorChange(Color startVal, Color targetVal){
        if (fadeSeconds > 0){
            float frameTime = 0.0f;

            while (frameTime < fadeSeconds){
                frameTime += Time.deltaTime;

                lightObject.color = new Color(
                    Mathf.Lerp(startVal.r, targetVal.r, frameTime), Mathf.Lerp(startVal.g, targetVal.g, frameTime), Mathf.Lerp(startVal.b, targetVal.b, frameTime)
                );

                yield return null;
            }
        }

        lightObject.color = targetVal;
    }

    IEnumerator ApplyIntensityChange(float startVal, float targetVal, bool turnOffWhenDone){
        if (fadeSeconds > 0){
            float frameTime = 0.0f;

            while (frameTime < fadeSeconds){
                frameTime += Time.deltaTime;

                lightObject.intensity = Mathf.Lerp(startVal, targetVal, frameTime);

                yield return null;
            }
        }

        lightObject.intensity = targetVal;

        if (turnOffWhenDone){
            lightObject.enabled = false;

            if (changeIntensity){
                lightObject.intensity = newIntensity;
            } else {
                lightObject.intensity = startVal;
            }
        }
    }
}