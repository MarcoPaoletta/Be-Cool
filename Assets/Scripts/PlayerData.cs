using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int score;
    public int level;
    public int touchesLeft;
    public int totalTouches;
    public int sprite1Index;
    public int sprite2Index;
    public int hatIndex;

    public PlayerData(Player player)
    {
        score = player.score;
        level = player.level;
        touchesLeft = player.touchesLeft;
        totalTouches = player.totalTouches;
        sprite1Index = player.sprite1Index;
        sprite2Index = player.sprite2Index;
        hatIndex = player.hatIndex;
    }
}