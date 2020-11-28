using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Give")]
public class Give : Actions
{
   public override void RespondToInput(GameController controller, string intr){
        if (controller.player.HasItemByName(intr))
        {    
            if (GiveToInteractable(controller, controller.player.playerLocation.interactables, intr))
                return;
            controller.currentText.text = "The "+intr+" wasn't accepted";
            return;
        }
        controller.currentText.text = "The "+intr+" isn't even in your inventory!";
        
   }

   private bool GiveToInteractable(GameController controller, List<Interactable> interactables, string intr) {
       {
           foreach(Interactable interactable in interactables)
           {
               if(interactable.interacatableEnabled)
               {
                   if(controller.player.CanGiveToInteractable(controller, interactable))
                   {
                       if(interactable.InteractionWith(controller, "give"))
                       {
                           return true;
                       }
                   }
               }
           }
       }

       return false;
   }
}