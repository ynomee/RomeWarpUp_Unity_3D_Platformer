using UnityEngine;

public class PlatformEffectManager : MonoBehaviour
{
    [SerializeField] private float _currentMoveSpeed;
    [SerializeField] private float _currentJumpForce;

    [SerializeField] private float _increasedGravityScale;
    [SerializeField] private float _baseGravityscale = 1f;

    private int lastPlatformID = -1;
    private Platform.PlatformType? lastPlatformType = null;

    private Rigidbody rb;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _playerMovement = GetComponent<PlayerMovement>();
        DecreaseGravity();
        Debug.Log(Physics.gravity + "гравитация в начале уровня");
    }

    public void HandlePlatformEffect(Platform platform)
    {
        int currentPlatformID = platform.GetPlatformID();
        Platform.PlatformType currentPlatformType = platform.GetPlatformType();

        if (currentPlatformID != lastPlatformID)
        {
            lastPlatformID = currentPlatformID;
            lastPlatformType = currentPlatformType;

            switch (currentPlatformType)
            {
                case Platform.PlatformType.SpeedBoost:

                    // Увеличиваем скорость движения
                    _currentMoveSpeed += 2f;
                    _playerMovement.moveSpeed = _currentMoveSpeed;
                    IncreaseGravity();
                    break;

                case Platform.PlatformType.JumpBoost:

                    // Добавляем вертикальный импульс и увеличиваем силу прыжка
                    rb.AddForce(Vector3.up * _currentJumpForce, ForceMode.Impulse);

                    _currentJumpForce += 2f;
                    _playerMovement.jumpForce = _currentJumpForce;
                    IncreaseGravity();
                    break;

                case Platform.PlatformType.SpeedReduce:
                    _currentMoveSpeed -= 2f;
                    _playerMovement.moveSpeed = _currentMoveSpeed;
                    //DecreaseGravity();
                    break;

                case Platform.PlatformType.JumpReduce:
                    _currentJumpForce -= 2f;
                    _playerMovement.jumpForce = _currentJumpForce;
                    //DecreaseGravity();
                    break;
            }
        }

    }
    private void IncreaseGravity()
    {
        Physics.gravity = new Vector3(0, -9.81f * _increasedGravityScale, 0);
    }

    private void DecreaseGravity()
    {
        Physics.gravity = new Vector3(0, -9.81f * _baseGravityscale, 0);
    }

    //private void ResetEffects()
    //{
    //    speedImpulse = 1f;
    //    jumpImpulse = 1f;
    //}
}

