using System;

public interface IInputManager
{
    event Func<bool> Fetch;

    event Action SkipFetch; 

    int Iterator { get; set; }
}