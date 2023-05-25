using UnityEngine;

public static class TimeController
{
    private const float PauseTimeScale = 0f;
    private const float PlayTimeScale = 1f;
    
    private static bool _isGameActive = true;
    
    ///<summary>Пауза / возобновление игрового процесса.</summary>
    public static void SetActiveGame(bool isGameActive)
    {
        _isGameActive = isGameActive;
        Time.timeScale = isGameActive ? PlayTimeScale : PauseTimeScale;
    }
}