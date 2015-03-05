
quests = {
	{
      name = "Enable Gravity",
      questGiver = "gameController",
      completed = false,
      hints = {
         "Click on the <color=blue>GameController Ghost</color> \nto edit the level script. ",
         "The Ghost should set the gravity \nwhen the game starts, but the instruction\n is commented out.",
      },
   },

   {
      name = "Enable moving left",
      questGiver = "signPost1",
      completed = false,
      hints = {
         "Click on the player to edit your own movement script.",
         "Find the commented out lines\n that control movement to left,\n and uncomment them.",
      },
   },

   {
      name = "Enable jump",
      questGiver = "signPost2",
      completed = false,
      hints = {
         "It looks like you'll need to jump to get over the obstacle.",
         "The jump is already enabled, but it doesn't seem to do much...",
         "Try setting the jumpStrength variable to higher number",
      },
   },

   {
      name = "Fix broken pipe",
      questGiver =  "signPost3",
      completed = false,
      hints = {
         "I think this pipe leads to next level, but it doesn't seem to be working",
      },
   },

 }

currentQuestIndex = 1
currentQuest = quests[1]
currentHint = 1
hint = ""

function CompleteQuest()
   currentQuest.completed = true
   currentQuestIndex = currentQuestIndex + 1
   currentQuest = quests[currentQuestIndex]
   currentHint = 1
end

function GetQuestHint()
   hint = quests[currentQuestIndex].hints[currentHint]
   currentHint = currentHint + 1
end

function Start()

end
