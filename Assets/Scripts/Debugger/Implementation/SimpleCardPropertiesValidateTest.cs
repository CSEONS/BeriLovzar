using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
class SimpleCardPropertiesValidateTest : MonoBehaviour, ISceneTest
{
    public string Name => nameof(SimpleCardPropertiesValidateTest);

    [SerializeField] private DebugSingleton _debugSingleton;

    public bool CheckTest()
    {
        var cards = _debugSingleton.SimpleTrainCards;
        var logMessageBuilder = new LogBuilder();

        foreach (var card in cards)
        {
            if (card == null)
            {
                logMessageBuilder.AddLogError($"The card is Null");
                return false;
            }

            var fields = card.GetType().GetFields();

            foreach (var field in fields)
            {
                var value = field.GetValue(card);

                if (value.Equals(null))
                {
                    logMessageBuilder.AddLogError($"The card \"{card.PrefabName}\" field \"{field.Name}\" is empty or Null");
                }
            }
        }

        logMessageBuilder.Print();

        if (logMessageBuilder.HaveErrorLogs)
        {
            return false;
        }

        return true;
    }
}