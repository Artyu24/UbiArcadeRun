using System;


public interface ITickable
{
    
    void SubToBeat(Song song);
    void UnSubToBeat();
    void Tick();
    void SubTick();
}
