if not instance_exists(oPlayer) exit;
var hp_x = 8;
var hp_y = 8;
var hp_width = 198;
var hp_height = 14;
draw_hp = lerp(draw_hp, oPlayer.hp, 0.1);
var hp_percent = draw_hp/oPlayer.max_hp;
draw_rectangle_color(hp_x, hp_y, hp_x + (hp_width * hp_percent), hp_y + hp_height, c_white, c_white, c_white, c_white, false);
