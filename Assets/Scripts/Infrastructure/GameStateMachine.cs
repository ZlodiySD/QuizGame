using System;
using System.Collections.Generic;
using QuizGame.States;

namespace QuizGame.Infrastructure
{
  public class GameStateMachine
  {
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    public GameStateMachine()
    {
      _states = new Dictionary<Type, IExitableState>();
    }

    public void AddState(Type key, IExitableState value) => 
      _states.Add(key, value);

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _activeState?.Exit();
      
      TState state = GetState<TState>();
      _activeState = state;
      
      return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState => 
      _states[typeof(TState)] as TState;
  }
}