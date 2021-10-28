/// @description Insert description here
// You can write your code in this editor
if (mouse_check_button(mb_right)) && (distance_to_object(oPlayer)<20)
{
	Choose = true;
}

if(point_in_circle(oPlayer.x,oPlayer.y,x,y,300)) && (!instance_exists(oText))
{
	with (instance_create_layer(x, y, "Explosions", oText))
	{
		text = other.text;
		length = string_length(text);
	}
	with (oCamera)
	{
		follow = other.id;
	}
	if (Choose = true) && (!instance_exists(oLevelEnd))
	{
		instance_create_layer(olSpawner.x, olSpawner.y, "LevelChange", oLevelEnd);
	}
}