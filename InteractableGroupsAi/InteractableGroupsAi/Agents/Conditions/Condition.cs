namespace InteractableGroupsAi
{
    /// <summary>
    /// Каждый кондишн получает на вход необходимый ему контекст (GroupState, CharacterState) 
    /// И в чек проверяет то что нужно
    /// Например HealthGreaterCondition
    /// Получает CharacterState и проверяет хп
    /// </summary>
    public abstract class Condition
    {
        public virtual bool Check()
        {
            return true;
        }
    }
}
