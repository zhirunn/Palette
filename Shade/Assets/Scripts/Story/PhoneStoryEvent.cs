using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneStoryEvent : StoryEvent
{    
    public SpriteRenderer battery;
	
	// Update is called once per frame
	void Update () {
		if(battery.enabled == false)
        {
            Passage = "Holophonerecoverysecond";
        }
        else
        {
            Passage = "Holophonerecoveryfirst";
        }
	}
}
