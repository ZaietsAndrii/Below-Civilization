using UnityEngine;

[CreateAssetMenu(menuName = "Configs/CharacterConfig", fileName = "CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private GroundedStateConfig _groundedStateConfig;
    [SerializeField] private AirbornStateConfig _airbornStateConfig;
    [SerializeField] private ParkouredStateConfig _parkouredStateConfig;


    public GroundedStateConfig GroundedStateConfig => _groundedStateConfig;
    public AirbornStateConfig AirbornStateConfig => _airbornStateConfig;
    public ParkouredStateConfig ParkouredStateConfig => _parkouredStateConfig;
}
