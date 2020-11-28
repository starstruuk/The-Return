using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interactions 
{
    public Actions action;

    [TextArea]
    public string response;

    public string textToReply;

    public List<Interactable>interactablesToDisable = new List<Interactable>();
    public List<Interactable>interactablesToEnable = new List<Interactable>();

    public List<Directions>directionsToDisable = new List<Directions>();
    public List<Directions>directionsToEnable = new List<Directions>();

    public Locations locationToTeleport = null;
}
