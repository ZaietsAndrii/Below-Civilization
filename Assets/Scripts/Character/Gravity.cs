using UnityEngine;

public class Gravity
{
    private float _gravity = -9.81f;
    private float _terminalVelocity = -53f;
    private float _currentverticalVelocity;
    
    public float GetCalculatedGravity()
    {
        _currentverticalVelocity += _gravity * Time.deltaTime;
        _currentverticalVelocity = Mathf.Clamp(_currentverticalVelocity, _terminalVelocity, -_terminalVelocity);
        //Debug.Log(_currentverticalVelocity);
        return _currentverticalVelocity;
    }

    public void ResetGravity() => _currentverticalVelocity = 0f;
}
