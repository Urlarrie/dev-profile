if (room = Menu) && (!audio_is_playing(TheTape))
{
	audio_stop_all();
	audio_play_sound(TheTape, 1000, true);	
}
if (room != Menu) && (!audio_is_playing(CityLights))
{
	audio_stop_sound(TheTape);
	audio_play_sound(CityLights, 1000, true);
}
if ((room = lClosing) || (room = lCredits)) && (!audio_is_playing(BillysSacrifice))
{
	audio_stop_sound(CityLights);
	audio_play_sound(BillysSacrifice, 1000, true);
}
if (room = lGameOver) && (!audio_is_playing(TheTape))
{
	audio_stop_all();
	audio_play_sound(TheTape, 1, 1000);
}
	