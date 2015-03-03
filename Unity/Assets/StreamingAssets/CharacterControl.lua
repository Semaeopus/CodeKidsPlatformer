
weight = 2.5
maxSpeed = 5.0
moveSpeed = 1.0
airMoveSpeed = 0.5
jumpStrength = 10.0

running = false
movement = {x = 0, y = 0}

 function Start()
	-- do this on start
 end

function Update(dt)
	-- update loop

	-- set right animation:
	if not character.grounded then
		running = false
		character:SetAnimation("Jump")
	elseif running then
		character:SetAnimation("Run")
	else
		character:SetAnimation("Idle")
	end

	-- apply movement and then reset it:
	character:AddForce(movement.x, movement.y)
	movement = {x = 0, y = 0}

end

function KeyDown(key)
	if character.grounded then
		-- jump:
		if key == "UpArrow" then
			movement.y= movement.y + jumpStrength
		end
		-- move on ground:
		if key == "LeftArrow" then
			movement.x = movement.x - moveSpeed
			running = true
		elseif key == "RightArrow" then
			movement.x = movement.x + moveSpeed
			running = true
		end
	else
		-- move in air:
		if key == "LeftArrow" then
			movement.x = movement.x - airMoveSpeed
		elseif key == "RightArrow" then
			movement.x = movement.x + airMoveSpeed
		end
	end
end

function KeyUp(key)
	running = false
end
