using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Actions
{
    public override void RespondToInput(GameController controller, string intr){
        {
            if (CheckInteractables(controller, controller.player.playerLocation.interactables, intr))
                return;
            if (CheckInteractables(controller, controller.player.inventory, intr))
                return;

            controller.currentText.text = "You can't see a "+intr;

        }
    }

    private bool CheckInteractables(GameController controller, List<Interactable> interactables, string intr)
    {
        foreach(Interactable interactable in interactables)
        {
            if(interactable.interactableName == intr)
            {
                if (interactable.InteractionWith(controller, "examine"))
                    return true;

                controller.currentText.text = "There's nothing interesting about the "+intr;
                return true;
            }
        }

        return false;
    }
}
