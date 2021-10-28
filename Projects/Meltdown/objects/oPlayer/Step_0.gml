/// @description Insert description here
// You can write your code in this editor
#region Player Input
if (hascontrol)
{
	key_left = keyboard_check(vk_left) || keyboard_check(ord("A")) direction = 180;
	key_right = keyboard_check(vk_right) || keyboard_check(ord("D")) direction = 0;
	key_jump = keyboard_check_pressed(vk_space);
	key_sprint = keyboard_check(vk_lshift) || keyboard_check(vk_rshift);
	key_shoot = mouse_check_button(mb_left)
}
else
{
	key_left = 0;
	key_right = 0;
	key_jump = 0;
	key_sprint = 0;
	key_shoot= 0;
}
#endregion

#region Player States
if (place_meeting(x+hsp, y, oWall))
{
	phCollide = 1;
}
else {phCollide = 0}
if (place_meeting( x, y+1, oWall))
{
	onGround = 1;	
}
else {onGround = 0}
if (hsp != 0)
{
	Running = 1;
}
else {Running = 0}
if (key_shoot)
{
	Shooting = 1;	
}
else {Shooting = 0}
#endregion

#region Player Movement
var move = key_right - key_left 
hsp = move * walksp

vsp = vsp + grv;

if (onGround = 1) && (key_jump)
{
	vsp = -jumpspeed;
}
if (onGround = 1) && (key_jump) && (key_sprint) && (Running = 1)
{
	grv = 0.2;	
	hsp = move *sprintsp*25
}
else {grv = 0.3}

if (key_sprint) && (onGround = 1)
{
	hsp = move * sprintsp;
}
#endregion

#region Player Collision
if (place_meeting(x+hsp, y, oWall))
{
	while (!place_meeting(x+sign(hsp), y, oWall))
	{
		x = x + sign(hsp);	
	}
	hsp = 0;
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

#region Player Animation
 if (onGround = 0)
 {
	sprite_index = sPlayerJ;
	image_speed = 0;
	if (sign(vsp) > 0) image_index = 1; else image_index = 0;
 }
 else
 {
	 if (sprite_index == sPlayerJ) audio_play_sound(sLanding, 4, false);
	 image_speed = 1;
	 if (hsp = 0)
	 {
		 sprite_index = sPlayer;
	 }
	 else
	 {
		 sprite_index = sPlayerR;
	 }
 }
if (hsp != 0) image_xscale = sign(hsp);
if (Shooting = 1) && (Running = 0) && (onGround = 1)
{
	sprite_index = sPlayerS;
	image_speed = 1;
}
#endregion

#region Player Shooting
if (key_shoot) && (alarm[0]<0) && (hsp == 0)
{
	audio_play_sound(sShoot, 1, false);	
	bullet = instance_create_layer(x,y,"Bullets",oBullet);
	bullet.direction = other.image_angle + random_range(-100,100);
	ScreenShake(2,10);
	if (image_xscale = 1)
	{
		bullet.hspeed = 6;
		bullet.image_angle = bullet.direction;	
	}
	if (image_xscale = -1)
	{
		oBullet.image_xscale = 1;
		bullet.hspeed = -6;
		bullet.image_angle = bullet.direction;	
	}
	alarm[0] = 6;
}

#endregion
if (hp <= 0)
{
	instance_change(oDead, true);
	direction = point_direction(other.x,other.y,x,y);
	hsp = lengthdir_x(6,direction);
	vsp = lengthdir_y(4,direction)-2;
	if (sign(hsp) != 0) image_xscale = sign(hsp);
}
