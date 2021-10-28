sprite_index = sBulletC;
image_speed = 1;

with (other)
{
	oPlayer.hp--;
	flash = 3;
}
instance_destroy();