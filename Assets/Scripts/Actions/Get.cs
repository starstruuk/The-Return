using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Actions
{
   public override void RespondToInput(GameController controller, string itername)
   {
       foreach (Interactable interactable in controller.player.playerLocation.interactables)
       {
           if (interactable.interacatableEnabled && interactable.interactableName == itername)
           {
               if (interactable.playerPickUp)
               {
                   controller.player.inventory.Add(interactable);
                   controller.player.playerLocation.interactables.Remove(interactable);
                   controller.currentText.text = "You take the "+itername;
                   return;
               }
           }
       }

       controller.currentText.text = "You can't take that...";
   }
}
