if (room = lOpening)
{
	endtext[0] = "HEY!!! THIS IS YOUR BOSS AND WE HAVE AN ISSUE!!\n\n *Press any button to continue...and '1' to reset the game*";
	endtext[1] = "No time to explain, but as an intern at the ITER Tokamak Fusion Reactor\n and because it is your first day on the job, you need to fix this...";
	endtext[2] = "...Orrrr...YOU'RE FIRED!!! \n *Hit control to skip through dialogue(NOT ADVISED)*";
	endtext[3] = "So...basically the fusion reactor has gone haywire...for no apparent reason \n other than the fact that SOMEONE...*ahem* left their coffee...\n in the...um reactor chamber...";
	endtext[4] = "...ok forget about blaming people we need you to fix this!! \n We've outftted you with a small tech infused suit and...ah...\n a weapon for any resistance you may encounter...";
	endtext[5] = "You have fifteen minutes to race through the reactor rooms and shut off the reactor before it starts a meltdown..\n maybe killing us all? \n I'm not sure it's never happened before so let's not find out...";
	endtext[6] = "Your suit has been outfitted with state of the art controls..";
	endtext[7] = "...like input 'A' or 'D' to move left and right...\n ...use 'Space' to engage jump thrusters...\n ...Hold the 'Left Mouse Button' to activate your blasters...you know just in case...\n ...Lastly Hold 'Shift' to release your Maglev boots and run faster...";
	endtext[8] = "...now pay ATTENTION....as you travel through the reactor rooms, you'll need to interact with several computers... \n ...the computers however, are outfitted with security technology...\n the computers will need you to interact with the proper server to move on to the next room...";
	endtext[9] = "Click the 'Right Mouse Button' to Interact with the computers and display the data...\n ...Press 'Enter' when near the servers to pick the right server...\n However, there is one issue...";
	endtext[10] = "The computers will question you on knowledge about the reactors to see if you are authorized...\n if you are authorized you can proceed to the next room through an elevator that will appear at the far right of the room...\n ...unauthorized?...well BOOM!...so get it right";
	endtext[11] = "Now HURRY AND STOP WASTING TIME TALKING TO ME \n SAVE THE REACTOR!!!";
}
spd = 0.5;
letters = 0;
currentline = 0;
length = string_length(endtext[currentline]);
text = "";