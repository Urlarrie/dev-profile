if (distance_to_object(oPlayer) < 60) && (!instance_exists(oText))
{
	instance_create_layer(other.x,other.y,"Player", otMarker);
}
else {instance_destroy(otMarker)}