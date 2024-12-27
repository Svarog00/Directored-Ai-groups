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

        public float CurrentHealth { get; }
        public float MaxHealth { get; }

        public float CurrentRest { get; }
        public float MaxRest { get; }
    }
}
