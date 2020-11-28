using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Actions
{
    public override void RespondToInput(GameController controller, string action) {
        {
            if (controller.player.inventory.Count == 0)
            {
                controller.currentText.text = "You have nothing";
                return;
            }

            string result = "You have ";
            bool first = true;
            foreach(Interactable item in controller.player.inventory)
            {
                if (first)
                {
                    result+= "a "+item.interactableName;
                }
                else{
                    result+= ", a "+item.interactableName;
                }
                first = false;
            }

            controller.currentText.text = result;
        }
    }
}
