public class AddActions : Effect
{
    public int actions;

    public AddActions() : base(new NoTarget())
    {
    }

    public AddActions(Target target) : base(target)
    {
    }

    public override void Cast()
    {
        var character = Player.FindCharacter();
        character.AddTempActions(actions);
    }

    public override string GetDescription()
    {
        return $"Gain <color=yellow>{actions}</color> actions for this turn{GetTarget().GetDesciption()}";
    }
}
