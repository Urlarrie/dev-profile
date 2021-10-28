
if (room = lTransition3)
{
	endtext[0] = "Ah...this is great....what a great day off...";
	endtext[1] = "...\n NO!! WHAT DUDE\n life sucks and you're still alive dude!";
	endtext[2] = "Well, it seems like you are about to enter the third room...";
	endtext[3] = "Well, considering you'll be working here..if you succeed..\n do you know what type of reactor is\n hosted here at this facility?";
	endtext[4] = "The ITER nuclear fusion facility is powered by a TOKAMAK nuclear fusion reactor";
	endtext[5] = "The defining feature of this reactor is the taurus shape of the chamber that contains\n the hot plasma created by the fusion reaction...";
	endtext[6] = "This taurus shape protects us from encountering plasma \n that's ten times hotter than the center of the sun";
	endtext[7] = "Would be a shame if you...were to somehow\n come into contact...with this plasma...";
}
spd = 0.5;
letters = 0;
currentline = 0;
length = string_length(endtext[currentline]);
text = "";