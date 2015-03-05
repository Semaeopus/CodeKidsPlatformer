
pipeIsJammed = true;

function Start()
	-- do this on start
end

function Update(dt)
	-- update loop
end

function PlayerEnterPipe()
	if not pipeIsJammed then
		pipe:LoadNextLevel();
	end
end
