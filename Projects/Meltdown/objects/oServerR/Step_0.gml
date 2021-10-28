if (keyboard_check_pressed(vk_enter)) && (distance_to_object(oPlayer)<20)
{
	Choose = true;
}
if (Choose = true) && (!instance_exists(oLevelEnd))
{
	if(audio_is_playing(sRight) == false) 
	{
		audio_play_sound(sRight, 1, false);
	}
	instance_create_layer(olSpawner.x, olSpawner.y, "LevelChange", oLevelEnd);
}