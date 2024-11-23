using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum PlatformType { SpeedBoost, JumpBoost, SpeedReduce, JumpReduce }
    public PlatformType platformType;

    private static int platformIDCounter = 0;
    private int platformID;

    private void Awake()
    {
        platformID = platformIDCounter++;
    }

    public int GetPlatformID() => platformID;
    public PlatformType GetPlatformType() => platformType;
}


