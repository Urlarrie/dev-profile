var bullet = instance_create_layer(x, y, "Bullets", oEnemyBullet);
if (instance_exists(oPlayer))
{
	with (bullet)
	{
		direction = point_direction(x, y, oPlayer.x, oPlayer.y); 
		speed = 6;
	}
	alarm[0] = room_speed * bulletspeed;
}