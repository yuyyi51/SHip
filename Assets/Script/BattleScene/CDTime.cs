using System.Collections;
using System.Collections.Generic;

public class CDTime
{
    public float cd;
    private float time;

    public CDTime(float c)
    {
        cd = c;
        time = 0;
    }

    public void StartColdDown()
    {
        time = cd;
    }

    public void ColdDown(float deltaTime)
    {
        time -= deltaTime;
    }

    public void Reset()
    {
        time = 0;
    }

    public bool ColdDownFinished()
    {
        return time <= 0;
    }

    public float GetPercent()
    {
        if (ColdDownFinished())
            return 0;
        else
        {
            return time / cd;
        }
    }
}
