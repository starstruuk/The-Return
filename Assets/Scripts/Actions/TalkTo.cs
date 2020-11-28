using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/TalkTo")]
public class TalkTo : Actions
{
   public override void RespondToInput(GameController controller, string intr){
        if (TalkToInteractable(controller, controller.player.playerLocation.interactables, intr))
            return;
        controller.currentText.text = "The "+intr+" doesn't want to talk...";
   }
    private bool TalkToInteractable(GameController controller, List<Interactable> interactables, string intr)
    {
        foreach(Interactable interactable in interactables)
        {
            if(interactable.interactableName == intr && interactable.playerCanTalkTo)
            {
                if (controller.player.CanTalkToInteractable(controller,interactable))
                {
                    if (interactable.InteractionWith(controller, "talkto"))
                        return true;    
                } 
                controller.currentText.text = "You can't talk to "+intr+"...";
                return true;       
            } 
            
        }

        return false;
    }

}

