using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Actions
{
    public override void RespondToInput(GameController controller, string intr){
        if (ReadInteractable(controller, controller.player.playerLocation.interactables, intr))
            return;

        controller.currentText.text = "You can't read the "+intr;

        }

    private bool ReadInteractable(GameController controller, List<Interactable> interactables, string intr) {
       {
           foreach(Interactable interactable in interactables)
           {
               if(interactable.interacatableEnabled)
               {
                   if(controller.player.CanReadInteractable(controller, interactable))
                   {
                       if(interactable.InteractionWith(controller, "read"))
                       {
                           return true;
                       }

                       controller.currentText.text = "The "+interactable+ " reads nothing";
                   }
               }
           }
       }

       return false;
   }
}