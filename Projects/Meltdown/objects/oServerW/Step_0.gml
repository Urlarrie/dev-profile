if (keyboard_check_pressed(vk_enter)) && (distance_to_object(oPlayer)<20)
{
	Choose = true;
}
if (Choose = true)
{
	ScreenShake(12 ,30);
	audio_play_sound(sDeath, 10, false);
	instance_create_layer(x,y+25,"Explosions",oExplosion);
	instance_destroy();
	oPlayer.hp = 0;
	Choose = false;
}