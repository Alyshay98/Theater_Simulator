/*

Holds data in order to call and execute an onstage event.

IMPORTANT: This component is NOT ONLY for events that the player will call themselves.
It also controls actor movements and actions (at least for now). These kinds of things
will NEVER be called by the player and must be activated by the game AUTOMATICALLY.

If you want an event to be called by the player, leave "happensAutomatically" unchecked
and make sure to write an eventName for the event to be called by. To help distinguish
player-caused events, try to name objects (IN THE EDITOR) with these components with a
prefix (for example, you could call a player event "player_lights1").

If you instead want an event to be called automatically, check "happensAutomatically."
You might also want to fiddle with activationDelay. You do not need to add an
eventName, but it might help to do so for organizational purposes. To help distinguish
automatic events, you can name objects with an according prefix (for example, you could
name it "auto_actormove1").

-----

To set up EventData objects:

Every single unique EventData must be an object in the scene.

Create an empty object in the editor and give it this script as a component. From
there, choose the eventType and assign other objects to variables so that they may be
correctly activated when the event is called.

MAKE SURE to add all EventData objects to the scene's local StageEventController's
eventList (IN THE EDITOR) so that it can actually be called (or started automatically).
The order the EventData are in is important; that's the order in which the game will
expect to activate the events.

For organizational purposes, try to add all EventData objects as children of one empty
object in the editor's hierarchy. Also, try to name them in the order that they are
expected to execute (for example, "auto_actormove 1" then "auto_actormove2", or 
"player_lights1" then "player_lights2").

-----

This isn't how I wanted to set things up, as making a whole bunch of objects that need
to physically exist feels awkward when they're just there to store data. However, I
found that (as far as I could tell), you can only edit data in the editor for classes
that inherit from MonoBehaviour (which turns things into components, forcing them to
physically exist if you want to use them). I wanted to prioritize ease-of-use over
anything else, though, so this is the best I've got for now.

In the future, I'll likely separate the several uses of EventData into several classes
that inherit from this script. That way, EventData objects that rely on lights would
not also have empty variables for controlling actors and such. A simple way to do this
could be to make existing scripts like LightPreset and StageInteractable inherit from
this, and then naming their respective activation functions in such a way that
StageEventController could just call them directly. I'll look into it.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EventData : MonoBehaviour
{
    /*
        NONE (Event Type 0):
            No event. Nothing will happen upon activation. Will likely be useless and
            is just here to be a default value. Theoretically, one could make use of
            happensAutomatically and activationDelay to space out stage events, but
            that could just be done with the same parameters during actual typed events.
        
        STAGE_LIGHT_PRESET (Event Type 1):
            A stored LightPreset object is activated, changing the stage lighting in a
            way defined by the LightData listed inside the LightPreset.
        
        STAGE_INTERACTABLE (Event Type 2):
            A StageInteractable object is activated. These might include SOUND EFFECTS
            or any other event onstage that happens once and can be repeated.
        
        STAGE_TOGGLE (Event Type 3):
            A StageToggle object is either activated or deactivated. These might include
            small lights that are attached to props rather than part of the stage's
            normal lighting, etc. 

        ACTOR_MOVE (Event Type 4):
            An actor object is told to move to a position onstage. (will need to figure
            out things like animations eventually, but this is fine for now.)

        ACTOR_ACTION (Event Type 5):
            An actor object performs some action, like speaking, performing an animation,
            etc. This system may end up being too limited for things like multiple actors
            performing actions simultaneously to each other or to onstage events like
            lights or sounds. I will try to think of a better way to store and execute
            these.
    */
    public enum EventTypes {
        NONE = 0,
        STAGE_LIGHT_PRESET = 1,
        STAGE_INTERACTABLE = 2,
        STAGE_TOGGLE = 3,
        ACTOR_MOVE = 4,
        ACTOR_ACTION = 5
    }

    // The type of event. 
    public EventTypes eventType = EventTypes.NONE;

    // The unique ID of an event. (may be unnecessary)
    // public int eventID = 0;

    // The unique string name of an event. If this string is called through the mic or
    // button input system, this event will activate. (This may only be for testing,
    // assuming I find a better way to handle calling events from strings.)
    // 
    // To clarify, if StageEventController receives a string that aligns with this variable,
    // that event will execute.
    public string eventName;

    // Some events, like actor movement, will not be called by the Stage Manager. Instead,
    // these events happen as soon as the previous event finishes. If this is false, the
    // game will wait for the eventName to be passed to the StageEventController
    // before activating the event.
    public bool happensAutomatically = false;

    // A delay (in seconds) before the event actually occurs. Timer starts after activation.
    // Will likely be most helpful for automatic events like actor movement, but I guess it
    // might end up having use cases outside of that context as well.
    // 
    // Can be used to time things according to the script. For instance, lights turn on,
    // and an actor movement event is set to begin automatically, but the script calls for
    // them to walk onstage after several moments.
    public float activationDelay = 0.0f;

    // Various values used by different event types. Might end up being more efficient to make
    // EventData objects specific to each event type so that these variables are not present 
    // and unused for every single EventData that is not the corresponding event type. For a
    // prototype, this works fine enough, but I will likely change this.
    public LightPreset lightPreset;
    public StageInteractable interactable;
    public StageToggle toggle;

    // The actor's NavMeshAgent can be told to move towards Vector3 actorDestination. If there
    // is a NavMesh onstage, the actor will be able to automatically pathfind into position.
    public NavMeshAgent actorNavAgent;
    public Vector3 actorDestination;

    // public StageActor actor;
    // Will connect to another enum in the future, unless I figure out a better way to do this
    // which I hopefully will.
    // public int actorActionType;

    public void Activate(){
        switch (eventType) {
            case EventTypes.NONE:
                break;
            case EventTypes.STAGE_LIGHT_PRESET:
                lightPreset.ApplyChanges();
                break;
            case EventTypes.STAGE_INTERACTABLE:
                interactable.Activate();
                break;
            case EventTypes.STAGE_TOGGLE:
                // toggle.Toggle();
                break;
            case EventTypes.ACTOR_MOVE:
                actorNavAgent.SetDestination(actorDestination);
                actorNavAgent.Move(Vector3.zero);
                break;
            case EventTypes.ACTOR_ACTION:
                // completely unimplemented
                print("(action taken by actor)");
                break;
        }
    }
}
