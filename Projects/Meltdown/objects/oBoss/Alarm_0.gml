var bullet = instance_create_layer(x, y, "Bullets", oBossBullet);
if (instance_exists(oPlayer))
{
	with (bullet)
	{
		direction = point_direction(x, y, oPlayer.x, oPlayer.y); 
		speed = 8;
	}
	alarm[0] = room_speed;
}