using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Say")]
public class Say : Actions
{
   public override void RespondToInput(GameController controller, string intr){
        if (InteractableSay(controller, controller.player.playerLocation.interactables, intr))
            return;
        controller.currentText.text = intr+" doesn't respond";
   }

   private bool InteractableSay(GameController controller, List<Interactable> interactables, string intr) {
       {
           foreach(Interactable interactable in interactables)
           {
               if(interactable.interacatableEnabled)
               {
                   if(controller.player.CanTalkToInteractable(controller, interactable))
                   {
                       if(interactable.InteractionWith(controller, "say"))
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
