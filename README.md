## Overview
A small quiz game for mobile devices

### Plugins
The project uses the following plugins:
- Zenject
- DoTween
- TextMeshPro
- SafeAreaHelper

### Adding new questions
To add a new question, you need to create a "QuizQuestion" object through the context menu of the unit. 
The correct answer must be changed with the flag "isCorrect"

Questions should be stored in this path: `Assets/Resources/Quizzes`

New questions should be added to the set of game rules that are stored along the way: `Assets/Resources/GameRules.asset`

### Game entry point
The game is launched via `AppInstaller` which is component on the `Assets/Resources/ProjectContext.prefab`

### Appliaction structure
The game is divided into states, each state sets up the corresponding scene and starts its work.

The application has the following states:
- MainMenuState (Responsible for setting up the main menu and transition to the corresponding scene)
- GameLoopState (Responsible for setting up a quiz game and transition to the corresponding scene)
