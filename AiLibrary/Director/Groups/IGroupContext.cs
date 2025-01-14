namespace InteractableGroupsAi.Director.Groups
{
    /// <summary>
    /// Маркировочынй интерфейс для конкретных реализаций Consideration,
    /// Оценивающие какую-то характеристику группы\персонажа получаемую из класса который реализует IContext
    /// </summary>
    public interface IGroupContext
    {
        IGroupState GetState();
    }

    public interface IGroupState
    {
        float CurrentHealth { get; }
        float MaxHealth { get; }

        float CurrentRest { get; }
        float MaxRest { get; }

        IGroupContext CurrentTarget { get; }

        void SetTarget(IGroupContext target);
    }
}
