using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Actions
{
   public override void RespondToInput(GameController controller, string intr){
        {
            if (UseInteractables(controller, controller.player.playerLocation.interactables, intr))
                return;
            if (UseInteractables(controller, controller.player.inventory, intr))
                return;

            controller.currentText.text = "There is no "+intr;
            
        }
    }

    private bool UseInteractables(GameController controller, List<Interactable> interactables, string inter)
    {
        foreach(Interactable interactable in interactables)
        {
            if(interactable.interactableName == inter)
            {
                if (controller.player.CanUseInteractable(controller,interactable))
                {
                    if (interactable.InteractionWith(controller, "use"))
                        return true;    
                } 
                controller.currentText.text = "The "+inter+" does nothing...";
                return true;       
            } 
            
        }

        return false;
    }
}
