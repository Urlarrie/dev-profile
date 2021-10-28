layer_x("TileAssets", min(layer_get_x("TileAssets")+1,RES_W*0.5 - 32));

letters += spd;
text = string_copy(endtext[currentline],1,floor(letters));

if (letters >= length) && (keyboard_check_pressed(vk_space))
{
	if (currentline+1 == array_length_1d(endtext))
	{
		sSlideTransition(TRANS_MODE.RESTART);	
	}
	else
	{
		currentline++;
		letters = 0;
		length = string_length(endtext[currentline]);
	}
}