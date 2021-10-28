/// @description Insert description here
// You
vsp = vsp + grv;

bulletspeed = irandom_range(1,4);

if (grounded) && (fearofheights) && (!place_meeting(x+hsp, y+1, oWall))
{
	hsp = -hsp;	
}


#region Player Collision
if (place_meeting(x+hsp,y,oWall))
{
	while (!place_meeting(x+sign(hsp), y, oWall))
	{
		x = x + sign(hsp);	
	}
	hsp = -hsp;
}
x = x + hsp;

if (place_meeting(x, y+vsp, oWall))
{
	while (!place_meeting(x, y+sign(vsp), oWall))
	{
		y = y + sign(vsp);	
	}
	vsp = 0;
	
}
y = y + vsp;
#endregion

 if (!place_meeting(x,y+1,oWall))
 {
	 grounded = false;
	sprite_index = sEnemyTJ;
	image_speed = 0;
	if (sign(vsp) > 0) image_index = 1; else image_index = 0;
 }
 else
 {
	 grounded = true;
	 image_speed = 1;
	 if (hsp = 0)
	 {
		 sprite_index = sEnemy;
	 }
	 else
	 {
		 sprite_index = sEnemyR;
	 }
 }
if (hsp != 0) image_xscale = sign(hsp) * size;
image_yscale = size;
if (distance_to_object(oPlayer) < 400) && (instance_exists(oPlayer))
{
	image_xscale = sign(oPlayer.x - x);
	hsp = hsp * image_xscale;
	sprite_index = sEnemyS;
	if image_xscale == 0
	{
		image_xscale = 1;
	}
}

if (hp <= 0)
{
	ScreenShake(12 ,30);
	audio_play_sound(sDeath, 10, false);
	instance_create_layer(x,y+25,"Explosions",oExplosion);
	instance_destroy();
}

