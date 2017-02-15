/*
Generated by UnityTwine on 2/14/2017 9:02:22 PM
https://github.com/daterre/UnityTwine
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTwine;

public class SnoozingStory: TwineStory
{
	public TwineVar wait;
	public TwineVar again;
	public TwineVar click;
	public TwineVar anxiety;
	public TwineVar dream;
	public override TwineVar this[string name]
	{
		get
		{
			switch(name)
			{
				case "wait": return wait;
				case "again": return again;
				case "click": return click;
				case "anxiety": return anxiety;
				case "dream": return dream;
				default: throw new KeyNotFoundException(string.Format("There is no variable with the name '{0}'.", name));
			}
		}
		set
		{
			switch(name)
			{
				case "wait": wait = value; break;
				case "again": again = value; break;
				case "click": click = value; break;
				case "anxiety": anxiety = value; break;
				case "dream": dream = value; break;
				default: throw new KeyNotFoundException(string.Format("There is no variable with the name '{0}'.", name));
			}
		}
	}


	void Awake() {
		base.Init();
		passageInit_0();
		passageInit_1();
		passageInit_2();
		passageInit_3();
		passageInit_4();
		passageInit_5();
		passageInit_6();
		passageInit_7();
		passageInit_8();
		passageInit_9();
		passageInit_10();
		passageInit_11();
		passageInit_12();
		passageInit_13();
		passageInit_14();
		passageInit_15();
	}
    
	// .............
	// #0: Start

	void passageInit_0()
	{
		this.Passages["Start"] = new TwinePassage("Start", new string[]{  }, passageExecute_0);
	}

	IEnumerable<TwineOutput> passageExecute_0()
	{
		yield return new TwineDisplay("alarm");	
	}
    
	// .............
	// #1: alarm

	void passageInit_1()
	{
		this.Passages["alarm"] = new TwinePassage("alarm", new string[]{  }, passageExecute_1);
	}

	IEnumerable<TwineOutput> passageExecute_1()
	{
		wait = 1;
		yield return new TwineText(@"...");
		yield return new TwineText(@"");
		if (! again) { 
		wait = 2;
		yield return new TwineText(@"? ?");
		yield return new TwineText(@"");
		} 
		wait = 1.5;
		yield return new TwineText(@"My alarm clock.");
		wait = 1.5;
		yield return new TwineLink(@"Time to get up.", @"Time to get up.", @"getUp", null, null);
		yield return new TwineLink(@"snooze", @"", @"snooze", null, null);
		again=true;	
	}
    
	// .............
	// #2: getUp

	void passageInit_2()
	{
		this.Passages["getUp"] = new TwinePassage("getUp", new string[]{  }, passageExecute_2);
	}

	IEnumerable<TwineOutput> passageExecute_2()
	{
		yield return new TwineText(either("here it goes again", "out of coffee", "i can't breath", "must leave at 7:00"));
		yield return new TwineText(@"");
		yield return new TwineText(@"");
		wait = 4;
		yield return new TwineText(@"THE END");	
	}
    
	// .............
	// #3: snooze

	void passageInit_3()
	{
		this.Passages["snooze"] = new TwinePassage("snooze", new string[]{  }, passageExecute_3);
	}

	IEnumerable<TwineOutput> passageExecute_3()
	{
		wait = 1;
		yield return new TwineText(either("I can't handle this right now.", "Keep my eyes closed."));
		yield return new TwineLink(@"dream", @"Dream", @"dreaming", null, null);
		yield return new TwineLink(@"anxiety", @"Anxiety", @"anxiety", null, null);
		yield return new TwineLink(@"her", @"Her", @"her", null, null);	
	}
    
	// .............
	// #4: sea

	void passageInit_4()
	{
		this.Passages["sea"] = new TwinePassage("sea", new string[]{  }, passageExecute_4);
	}

	IEnumerable<TwineOutput> passageExecute_4()
	{
		click = true;
		yield return new TwineText(@"i can breath");
		yield return new TwineText(@"");
		yield return new TwineText(@"i can fly");
		yield return new TwineText(@"");
		yield return new TwineText(@"i can't see the sky.");
		yield return new TwineText(@"");
		yield return new TwineText(@"it's warm");
		yield return new TwineText(@"");
		yield return new TwineText(@"just go deep");
		yield return new TwineText(@"");
		yield return new TwineText(@"i will always sleep");
		click = false;
		yield return new TwineLink(@"continue", @"", @"alarm", null, null);	
	}
    
	// .............
	// #5: her

	void passageInit_5()
	{
		this.Passages["her"] = new TwinePassage("her", new string[]{  }, passageExecute_5);
	}

	IEnumerable<TwineOutput> passageExecute_5()
	{
		yield return new TwineText(@"when");
		yield return new TwineText(@"will");
		yield return new TwineText(@"i");
		yield return new TwineText(@"feel");
		yield return new TwineText(@"you");
		yield return new TwineLink(@"continue", @"continue", @"alarm", null, null);	
	}
    
	// .............
	// #6: anxiety

	void passageInit_6()
	{
		this.Passages["anxiety"] = new TwinePassage("anxiety", new string[]{  }, passageExecute_6);
	}

	IEnumerable<TwineOutput> passageExecute_6()
	{
		if (anxiety == "work") { 
			anxiety = "relationship";
		} else if (anxiety == "relationship") { 
			anxiety = "work";
		} else { 
			anxiety = either("work", "relationship");
		} 
		yield return new TwineDisplay(anxiety);	
	}
    
	// .............
	// #7: dreaming

	void passageInit_7()
	{
		this.Passages["dreaming"] = new TwinePassage("dreaming", new string[]{  }, passageExecute_7);
	}

	IEnumerable<TwineOutput> passageExecute_7()
	{
		if (dream == "sea") { 
			dream = "street";
		} else if (dream == "street") { 
			dream = "sea";
		} else { 
			dream = either("sea", "street");
		} 
		yield return new TwineDisplay(dream);	
	}
    
	// .............
	// #8: machine3

	void passageInit_8()
	{
		this.Passages["machine3"] = new TwinePassage("machine3", new string[]{  }, passageExecute_8);
	}

	IEnumerable<TwineOutput> passageExecute_8()
	{
		yield return new TwineText(@"Yeah?");
		yield return new TwineText(@"See?");
		yield return new TwineText(@"You see that?");
		yield return new TwineText(@"");
		yield return new TwineText(@"Watch and learn you fuckers.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"continue", @"continue", @"alarm", null, null);	
	}
    
	// .............
	// #9: relationship

	void passageInit_9()
	{
		this.Passages["relationship"] = new TwinePassage("relationship", new string[]{  }, passageExecute_9);
	}

	IEnumerable<TwineOutput> passageExecute_9()
	{
		yield return new TwineText(@"She knows it.");
		click = true;
		yield return new TwineText(@"She looks at you,");
		yield return new TwineText(@"and she knows it.");
		yield return new TwineText(@"Pretends not to.");
		yield return new TwineText(@"She smiles.");
		yield return new TwineText(@"She's kind.");
		yield return new TwineText(@"You're not.");
		yield return new TwineText(@"You're shit.");
		yield return new TwineText(@"A little shit,");
		click = false;
		yield return new TwineLink(@"continue", @"", @"alarm", null, null);	
	}
    
	// .............
	// #10: machine2

	void passageInit_10()
	{
		this.Passages["machine2"] = new TwinePassage("machine2", new string[]{  }, passageExecute_10);
	}

	IEnumerable<TwineOutput> passageExecute_10()
	{
		yield return new TwineText(@"Oh, those.");
		yield return new TwineText(@"I can fit them too.");
		yield return new TwineText(@"Ha! No problem.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"continue", @"continue", @"machine3", null, null);	
	}
    
	// .............
	// #11: work

	void passageInit_11()
	{
		this.Passages["work"] = new TwinePassage("work", new string[]{  }, passageExecute_11);
	}

	IEnumerable<TwineOutput> passageExecute_11()
	{
		yield return new TwineText(@"Two days till the meeting.");
		yield return new TwineText(@"Two days.");
		yield return new TwineText(@"Everyone is going to");
		yield return new TwineText(@"hate me.");
		yield return new TwineText(@"Who needs this. Why");
		yield return new TwineText(@"me");
		yield return new TwineLink(@"continue", @"", @"alarm", null, null);	
	}
    
	// .............
	// #12: machine

	void passageInit_12()
	{
		this.Passages["machine"] = new TwinePassage("machine", new string[]{  }, passageExecute_12);
	}

	IEnumerable<TwineOutput> passageExecute_12()
	{
		yield return new TwineText(@"I can fit it.");
		yield return new TwineText(@"It fits.");
		yield return new TwineText(@"I'm so good.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"continue", @"continue", @"machine2", null, null);	
	}
    
	// .............
	// #13: street

	void passageInit_13()
	{
		this.Passages["street"] = new TwinePassage("street", new string[]{  }, passageExecute_13);
	}

	IEnumerable<TwineOutput> passageExecute_13()
	{
		wait = 1;
		yield return new TwineText(@"I'm late. ");
		yield return new TwineText(@"Where are my keys?");
		yield return new TwineText(@"Shit.");
		yield return new TwineLink(@"continue", @"", @"street2", null, null);	
	}
    
	// .............
	// #14: street3

	void passageInit_14()
	{
		this.Passages["street3"] = new TwinePassage("street3", new string[]{  }, passageExecute_14);
	}

	IEnumerable<TwineOutput> passageExecute_14()
	{
		wait = 1;
		yield return new TwineText(@"Maybe she'll want it?");
		yield return new TwineText(@"Her lips touched it");
		yield return new TwineText(@"");
		yield return new TwineLink(@"continue", @"", @"alarm", null, null);	
	}
    
	// .............
	// #15: street2

	void passageInit_15()
	{
		this.Passages["street2"] = new TwinePassage("street2", new string[]{  }, passageExecute_15);
	}

	IEnumerable<TwineOutput> passageExecute_15()
	{
		wait = 1;
		yield return new TwineText(@"My bag is empty.");
		yield return new TwineText(@"No, it's not.");
		yield return new TwineText(@"There's a half-eaten sandwich.");
		yield return new TwineText(@"It's hers.");
		yield return new TwineLink(@"continue", @"", @"street3", null, null);	
	}

}