namespace Zanzo.Pirouette
{
    // + Enum: AButtonState
    public enum AButtonState: int
    {
        Gameplay,
        Ui,
    }

    public static partial class AButtonStateExt
    {
        public static bool IsGameplay(this AButtonState entry) => entry == AButtonState.Gameplay;
        public static bool IsUi(this AButtonState entry) => entry == AButtonState.Ui;
    }


    // + Enum: BButtonState
    public enum BButtonState: int
    {
        Gameplay,
        Ui,
    }

    public static partial class BButtonStateExt
    {
        public static bool IsGameplay(this BButtonState entry) => entry == BButtonState.Gameplay;
        public static bool IsUi(this BButtonState entry) => entry == BButtonState.Ui;
    }


    // + Enum: CButtonState
    public enum CButtonState: int
    {
        Gameplay,
        Ui,
    }

    public static partial class CButtonStateExt
    {
        public static bool IsGameplay(this CButtonState entry) => entry == CButtonState.Gameplay;
        public static bool IsUi(this CButtonState entry) => entry == CButtonState.Ui;
    }
}