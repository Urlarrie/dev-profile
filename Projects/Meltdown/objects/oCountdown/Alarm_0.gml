time --;

if (time <= 0)
{
      instance_destroy();
	  instance_change(oDead, true);
	  room = lGameOver;
	  //Game Over
}
if (room = lClosing)
{
	instance_destroy();
}
alarm[0] = 60;