namespace Zanzo.Pirouette
{
    // + Enum: ActionButtonState
    public enum ActionButtonState: int
    {
        Gameplay,
        Ui,
    }

    public static partial class ActionButtonStateExt
    {
        public static bool IsGameplay(this ActionButtonState entry) => entry == ActionButtonState.Gameplay;
        public static bool IsUi(this ActionButtonState entry) => entry == ActionButtonState.Ui;
    }


    // + Enum: AsteroidDamageType
    public enum AsteroidDamageType: int
    {
        Core,
        Shell,
    }

    public static partial class AsteroidDamageTypeExt
    {
        public static bool IsCore(this AsteroidDamageType entry) => entry == AsteroidDamageType.Core;
        public static bool IsShell(this AsteroidDamageType entry) => entry == AsteroidDamageType.Shell;
    }


    // + Enum: AsteroidSpawnDistance
    public enum AsteroidSpawnDistance: int
    {
        Far,
        Medium,
        Short,
    }

    public static partial class AsteroidSpawnDistanceExt
    {
        public static bool IsFar(this AsteroidSpawnDistance entry) => entry == AsteroidSpawnDistance.Far;
        public static bool IsMedium(this AsteroidSpawnDistance entry) => entry == AsteroidSpawnDistance.Medium;
        public static bool IsShort(this AsteroidSpawnDistance entry) => entry == AsteroidSpawnDistance.Short;
    }


    // + Enum: AsteroidType
    public enum AsteroidType: int
    {
        One,
        Three,
        Two,
    }

    public static partial class AsteroidTypeExt
    {
        public static bool IsOne(this AsteroidType entry) => entry == AsteroidType.One;
        public static bool IsThree(this AsteroidType entry) => entry == AsteroidType.Three;
        public static bool IsTwo(this AsteroidType entry) => entry == AsteroidType.Two;
    }


    // + Enum: BoundsType
    public enum BoundsType: int
    {
        Deactivation,
        Screen,
    }

    public static partial class BoundsTypeExt
    {
        public static bool IsDeactivation(this BoundsType entry) => entry == BoundsType.Deactivation;
        public static bool IsScreen(this BoundsType entry) => entry == BoundsType.Screen;
    }


    // + Enum: CannonLocation
    public enum CannonLocation: int
    {
        Bow,
        Port,
        Starboard,
        Stern,
    }

    public static partial class CannonLocationExt
    {
        public static bool IsBow(this CannonLocation entry) => entry == CannonLocation.Bow;
        public static bool IsPort(this CannonLocation entry) => entry == CannonLocation.Port;
        public static bool IsStarboard(this CannonLocation entry) => entry == CannonLocation.Starboard;
        public static bool IsStern(this CannonLocation entry) => entry == CannonLocation.Stern;
    }


    // + Enum: CannonType
    public enum CannonType: int
    {
        MainCannon,
        ShieldCannon,
    }

    public static partial class CannonTypeExt
    {
        public static bool IsMainCannon(this CannonType entry) => entry == CannonType.MainCannon;
        public static bool IsShieldCannon(this CannonType entry) => entry == CannonType.ShieldCannon;
    }


    // + Enum: CompoundObjectSize
    public enum CompoundObjectSize: int
    {
        Large,
        Medium,
        Small,
        Tiny,
    }

    public static partial class CompoundObjectSizeExt
    {
        public static bool IsLarge(this CompoundObjectSize entry) => entry == CompoundObjectSize.Large;
        public static bool IsMedium(this CompoundObjectSize entry) => entry == CompoundObjectSize.Medium;
        public static bool IsSmall(this CompoundObjectSize entry) => entry == CompoundObjectSize.Small;
        public static bool IsTiny(this CompoundObjectSize entry) => entry == CompoundObjectSize.Tiny;
    }


    // + Enum: DamageSource
    public enum DamageSource: int
    {
        Blast,
        Projectile,
    }

    public static partial class DamageSourceExt
    {
        public static bool IsBlast(this DamageSource entry) => entry == DamageSource.Blast;
        public static bool IsProjectile(this DamageSource entry) => entry == DamageSource.Projectile;
    }


    // + Enum: DeactivationCallType
    public enum DeactivationCallType: int
    {
        InvokeParentCall,
        SuppressParentCall,
    }

    public static partial class DeactivationCallTypeExt
    {
        public static bool IsInvokeParentCall(this DeactivationCallType entry) => entry == DeactivationCallType.InvokeParentCall;
        public static bool IsSuppressParentCall(this DeactivationCallType entry) => entry == DeactivationCallType.SuppressParentCall;
    }


    // + Enum: DestructAnimationType
    public enum DestructAnimationType: int
    {
        Large,
        ProjectileCollision,
        Small,
    }

    public static partial class DestructAnimationTypeExt
    {
        public static bool IsLarge(this DestructAnimationType entry) => entry == DestructAnimationType.Large;
        public static bool IsProjectileCollision(this DestructAnimationType entry) => entry == DestructAnimationType.ProjectileCollision;
        public static bool IsSmall(this DestructAnimationType entry) => entry == DestructAnimationType.Small;
    }


    // + Enum: FasteroidsId
    public enum FasteroidsId: int
    {
        Asteroid,
        Bounds,
        CompoundAsteroid,
        CompoundSpaceDebris,
        DeactivationBounds,
        DestructAnimation,
        DestructParticle,
        Firefly,
        HomeBase,
        HomeBaseProjectile,
        MainCannon,
        Projectile,
        ScreenBounds,
        SideCannon,
        SpaceDebris,
        ThreatMarker,
        Ufo,
        UfoProjectile,
    }

    public static partial class FasteroidsIdExt
    {
        public static bool IsAsteroid(this FasteroidsId entry) => entry == FasteroidsId.Asteroid;
        public static bool IsBounds(this FasteroidsId entry) => entry == FasteroidsId.Bounds;
        public static bool IsCompoundAsteroid(this FasteroidsId entry) => entry == FasteroidsId.CompoundAsteroid;
        public static bool IsCompoundSpaceDebris(this FasteroidsId entry) => entry == FasteroidsId.CompoundSpaceDebris;
        public static bool IsDeactivationBounds(this FasteroidsId entry) => entry == FasteroidsId.DeactivationBounds;
        public static bool IsDestructAnimation(this FasteroidsId entry) => entry == FasteroidsId.DestructAnimation;
        public static bool IsDestructParticle(this FasteroidsId entry) => entry == FasteroidsId.DestructParticle;
        public static bool IsFirefly(this FasteroidsId entry) => entry == FasteroidsId.Firefly;
        public static bool IsHomeBase(this FasteroidsId entry) => entry == FasteroidsId.HomeBase;
        public static bool IsHomeBaseProjectile(this FasteroidsId entry) => entry == FasteroidsId.HomeBaseProjectile;
        public static bool IsMainCannon(this FasteroidsId entry) => entry == FasteroidsId.MainCannon;
        public static bool IsProjectile(this FasteroidsId entry) => entry == FasteroidsId.Projectile;
        public static bool IsScreenBounds(this FasteroidsId entry) => entry == FasteroidsId.ScreenBounds;
        public static bool IsSideCannon(this FasteroidsId entry) => entry == FasteroidsId.SideCannon;
        public static bool IsSpaceDebris(this FasteroidsId entry) => entry == FasteroidsId.SpaceDebris;
        public static bool IsThreatMarker(this FasteroidsId entry) => entry == FasteroidsId.ThreatMarker;
        public static bool IsUfo(this FasteroidsId entry) => entry == FasteroidsId.Ufo;
        public static bool IsUfoProjectile(this FasteroidsId entry) => entry == FasteroidsId.UfoProjectile;
    }


    // + Enum: GameState
    public enum GameState: int
    {
        Over,
        Playing,
    }

    public static partial class GameStateExt
    {
        public static bool IsOver(this GameState entry) => entry == GameState.Over;
        public static bool IsPlaying(this GameState entry) => entry == GameState.Playing;
    }


    // + Enum: HomeBaseEnergyState
    public enum HomeBaseEnergyState: int
    {
        Charged,
        Laser,
        Regular,
    }

    public static partial class HomeBaseEnergyStateExt
    {
        public static bool IsCharged(this HomeBaseEnergyState entry) => entry == HomeBaseEnergyState.Charged;
        public static bool IsLaser(this HomeBaseEnergyState entry) => entry == HomeBaseEnergyState.Laser;
        public static bool IsRegular(this HomeBaseEnergyState entry) => entry == HomeBaseEnergyState.Regular;
    }


    // + Enum: HudState
    public enum HudState: int
    {
        GameOver,
        Gameplay,
        TitleScreen,
    }

    public static partial class HudStateExt
    {
        public static bool IsGameOver(this HudState entry) => entry == HudState.GameOver;
        public static bool IsGameplay(this HudState entry) => entry == HudState.Gameplay;
        public static bool IsTitleScreen(this HudState entry) => entry == HudState.TitleScreen;
    }


    // + Enum: PaletteEntry
    public enum PaletteEntry: int
    {
        Black,
        Blue,
        Green,
        Magenta,
        Orange,
        White,
        Yellow,
    }

    public static partial class PaletteEntryExt
    {
        public static bool IsBlack(this PaletteEntry entry) => entry == PaletteEntry.Black;
        public static bool IsBlue(this PaletteEntry entry) => entry == PaletteEntry.Blue;
        public static bool IsGreen(this PaletteEntry entry) => entry == PaletteEntry.Green;
        public static bool IsMagenta(this PaletteEntry entry) => entry == PaletteEntry.Magenta;
        public static bool IsOrange(this PaletteEntry entry) => entry == PaletteEntry.Orange;
        public static bool IsWhite(this PaletteEntry entry) => entry == PaletteEntry.White;
        public static bool IsYellow(this PaletteEntry entry) => entry == PaletteEntry.Yellow;
    }


    // + Enum: RotationDirection
    public enum RotationDirection: int
    {
        Clockwise,
        CounterClockwise,
    }

    public static partial class RotationDirectionExt
    {
        public static bool IsClockwise(this RotationDirection entry) => entry == RotationDirection.Clockwise;
        public static bool IsCounterClockwise(this RotationDirection entry) => entry == RotationDirection.CounterClockwise;
    }


    // + Enum: ScreenQuadrant
    public enum ScreenQuadrant: int
    {
        Four,
        One,
        Three,
        Two,
    }

    public static partial class ScreenQuadrantExt
    {
        public static bool IsFour(this ScreenQuadrant entry) => entry == ScreenQuadrant.Four;
        public static bool IsOne(this ScreenQuadrant entry) => entry == ScreenQuadrant.One;
        public static bool IsThree(this ScreenQuadrant entry) => entry == ScreenQuadrant.Three;
        public static bool IsTwo(this ScreenQuadrant entry) => entry == ScreenQuadrant.Two;
    }


    // + Enum: SpaceDebrisDecay
    public enum SpaceDebrisDecay: int
    {
        Full,
        Half,
        None,
        OneQuarter,
        ThreeQuarters,
    }

    public static partial class SpaceDebrisDecayExt
    {
        public static bool IsFull(this SpaceDebrisDecay entry) => entry == SpaceDebrisDecay.Full;
        public static bool IsHalf(this SpaceDebrisDecay entry) => entry == SpaceDebrisDecay.Half;
        public static bool IsNone(this SpaceDebrisDecay entry) => entry == SpaceDebrisDecay.None;
        public static bool IsOneQuarter(this SpaceDebrisDecay entry) => entry == SpaceDebrisDecay.OneQuarter;
        public static bool IsThreeQuarters(this SpaceDebrisDecay entry) => entry == SpaceDebrisDecay.ThreeQuarters;
    }


    // + Enum: SpriteDeactivationStrategy
    public enum SpriteDeactivationStrategy: int
    {
        Auto,
        CircleBounds,
    }

    public static partial class SpriteDeactivationStrategyExt
    {
        public static bool IsAuto(this SpriteDeactivationStrategy entry) => entry == SpriteDeactivationStrategy.Auto;
        public static bool IsCircleBounds(this SpriteDeactivationStrategy entry) => entry == SpriteDeactivationStrategy.CircleBounds;
    }


    // + Enum: SpriteMotionType
    public enum SpriteMotionType: int
    {
        None,
        Rigidbody,
        Tween,
    }

    public static partial class SpriteMotionTypeExt
    {
        public static bool IsNone(this SpriteMotionType entry) => entry == SpriteMotionType.None;
        public static bool IsRigidbody(this SpriteMotionType entry) => entry == SpriteMotionType.Rigidbody;
        public static bool IsTween(this SpriteMotionType entry) => entry == SpriteMotionType.Tween;
    }


    // + Enum: TimerType
    public enum TimerType: int
    {
        AsteroidSpawn,
        FireflySpawn,
        HomeBaseProjectile,
        SpaceDebrisDisintegrate,
        SpaceDebrisSpawn,
        UfoSpawn,
    }

    public static partial class TimerTypeExt
    {
        public static bool IsAsteroidSpawn(this TimerType entry) => entry == TimerType.AsteroidSpawn;
        public static bool IsFireflySpawn(this TimerType entry) => entry == TimerType.FireflySpawn;
        public static bool IsHomeBaseProjectile(this TimerType entry) => entry == TimerType.HomeBaseProjectile;
        public static bool IsSpaceDebrisDisintegrate(this TimerType entry) => entry == TimerType.SpaceDebrisDisintegrate;
        public static bool IsSpaceDebrisSpawn(this TimerType entry) => entry == TimerType.SpaceDebrisSpawn;
        public static bool IsUfoSpawn(this TimerType entry) => entry == TimerType.UfoSpawn;
    }


    // + Enum: UfoSize
    public enum UfoSize: int
    {
        Large,
        Small,
    }

    public static partial class UfoSizeExt
    {
        public static bool IsLarge(this UfoSize entry) => entry == UfoSize.Large;
        public static bool IsSmall(this UfoSize entry) => entry == UfoSize.Small;
    }
}