
 options = {
	moveSpeed = 1.0,
	moveDistance = 1.0,
	waitTime = 2.0,
	color = {
		r = 1.0,
		g = 1.0,
		b = 1.0,
		a = 1.0,
	}
 }

--	Platform movement instructions
--	possible values: "up", "right", "left", "down", "wait"
  instructions = {
	"up",
	"right",
	"down",
	"wait",
	"up",
	"left",
	"down",
	"wait",
 }

instructionCounter = 1

 function Start()
	platform:UpdateOptionsFromLua()
 end

 function Update(dt)

end

function RunNextInstruction()
	nextInstruction = instructions[instructionCounter]
	platform:Move(nextInstruction)

	if instructionCounter < #instructions
	then
		instructionCounter = instructionCounter + 1
	else
		instructionCounter = 1
	end

end
