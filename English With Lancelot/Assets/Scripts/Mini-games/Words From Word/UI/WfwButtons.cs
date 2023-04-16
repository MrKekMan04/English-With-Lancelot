using UnityEngine;
using UnityEngine.Serialization;

public class WfwButtons : MonoBehaviour
{
    [SerializeField] private WfwGame game;
    [FormerlySerializedAs("userInputs")] [SerializeField] private WfwUserInputs userUserInputs;
    
    public void ClearInputs() => userUserInputs.Remove();

    public void CheckInputs() => game.CheckIsAnswerRight(userUserInputs.GetUserAnswer());
}