 
moveSpeed = 0.8
jumpStrength = 3.0
  
 function Start()
	-- do this on start
 end
 
function Update(dt)
	-- update loop
end

function KeyDown(key)
	
	if key == "LeftArrow" then
		-- move left
		character:AddForce(-moveSpeed, 0)
	elseif key == "RightArrow" then
		-- move right
		character:AddForce(moveSpeed, 0)
	end
	
	if key == "UpArrow" then
		-- jump
		character:AddForce(0, jumpStrength)
	end
end
