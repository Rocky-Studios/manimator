extends Polygon2D

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.




func _process(delta: float) -> void:
	var vel := (get_global_mouse_position() - global_position)
	global_position += vel
	pass
