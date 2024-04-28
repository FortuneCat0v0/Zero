namespace ET.Client
{
    [NumericWatcher(SceneType.Current, NumericType.Hp)]
    public class NumericWatcher_Hp_ShowUI : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            unit.GetComponent<HeadInfosComponent>()
                    ?.RefreshHealthBar(numericComponent.GetAsInt(NumericType.Hp) * 1f / numericComponent.GetAsInt(NumericType.MaxHp));
        }
    }
}