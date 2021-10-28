sprite_index = sBulletC;
image_speed = 1;

with (other)
{
	oPlayer.hp = oPlayer.hp - 2;
	flash = 3;
}
instance_destroy();