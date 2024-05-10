using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private CharacterView _view;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private ObstacleChecker _obstacleChecker;

    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private CharacterController _characterController;

    public PlayerInput Input => _input;
    public CharacterController Controller => _characterController;
    public CharacterView View => _view;
    public CharacterConfig Config => _config;
    public GroundChecker GroundChecker => _groundChecker;
    public Transform CameraTarget => _cameraTarget;
    public Transform RaycastPoint => _raycastPoint;
    public ObstacleChecker ObstacleChecker => _obstacleChecker;

   

    private void Awake()
    {
        _view.Initialize();
        _characterController = GetComponent<CharacterController>();
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void OnEnable()
    {
        Input.Enable();
    }

    private void OnDisable()
    {
        Input.Disable();
    }


}
