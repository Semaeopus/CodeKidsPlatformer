
maxSpeed = 1.0 
moveSpeed = 0.2
airMoveSpeed = 0.05
jumpStrength = 3.0

running = false
  
 function Start()
	-- do this on start
 end
 
function Update(dt)
	-- update loop
	if not character.grounded then
		running = false
		character:SetAnimation("Jump")
	elseif running then
		character:SetAnimation("Run")
	else
		character:SetAnimation("Idle")
	end
	
end

function KeyDown(key)
	
	if character.grounded then
		-- move on ground:
		if key == "LeftArrow" then
			character:AddForce(-moveSpeed, 0)
			running = true
		elseif key == "RightArrow" then
			character:AddForce(moveSpeed, 0)
			running = true
		end
		-- jump:
		if key == "UpArrow" then
			character:AddForce(0, jumpStrength)
		end
	else
		-- move in air:
		if key == "LeftArrow" then
			character:AddForce(-airMoveSpeed, 0)
		elseif key == "RightArrow" then
			character:AddForce(airMoveSpeed, 0)
		end
	end

end

function KeyUp(key)
	running = false
end
