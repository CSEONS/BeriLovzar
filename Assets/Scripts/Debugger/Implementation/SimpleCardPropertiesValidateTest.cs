using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
class SimpleCardPropertiesValidateTest : MonoBehaviour, ISceneTest
{
    public string Name => nameof(SimpleCardPropertiesValidateTest);

    [SerializeField] private CardsManagerSingleton _cardsManager;

    public bool IsPassed()
    {
        var cards = _cardsManager.SimpleTrainCards;
        var logBuilder = new LogBuilder();

        foreach (var card in cards)
        {
            if (card == null)
            {
                if (logBuilder.HaveErrorLogs is false)
                {
                    logBuilder.AddLogError($"==Info==");
                    logBuilder.AddLogError($"Test name:  {nameof(SimpleCardPropertiesValidateTest)}");
                }

                logBuilder.AddLogError($"The card is Null");
                return false;
            }

            var fields = card.GetType().GetFields();

            foreach (var field in fields)
            {
                var value = field.GetValue(card);

                if (value.Equals(null))
                {
                    if (logBuilder.HaveErrorLogs is false)
                    {
                        logBuilder.AddLogError($"==Info==");
                        logBuilder.AddLogError($"Test name:  {nameof(SimpleCardPropertiesValidateTest)}");
                    }

                    logBuilder.AddLogError($"The card \"{card.PrefabName}\" field \"{field.Name}\" is empty or Null");
                }
            }
        }

        logBuilder.Build();

        if (logBuilder.HaveErrorLogs)
        {
            return false;
        }

        return true;
    }
}