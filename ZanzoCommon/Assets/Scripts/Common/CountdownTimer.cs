// +-------------------------------------------------------------------------------------------------------------------
// + File: CountdownTimerDomain.cs
// + Company: Zanzo Studios - http://zanzostudios.com
// + Author: Michael McClenney at 11:26 on 2022/08/19
// +
// + Description:
// +    Insert Description Here
// +-------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using UnityEngine;


namespace Zanzo.Common
{
    public class CountdownTimer
    {
        public float Min { get; protected set; }
        public float Max { get; protected set; }
        public float Remaining { get; protected set; }
        public bool HasExpired { get => Remaining <= 0; }
        public bool IsStopped { get; private set; } = false;

        public CountdownTimer(float min, float? max=null)
        {
            Min = min;
            Max = max.HasValue ? max.Value : min;
            Remaining = CalculateRemainingTime();
        }

        public void Start(float offset=0)
        {
            if (!IsStopped) Remaining = CalculateRemainingTime(offset);
            IsStopped = false;
        }

        public void Restart(float offset=0)
        {
            Clear();
            IsStopped = false;
            Start(offset);
        }

        public void Stop() => IsStopped = true;
        public void Clear() => Remaining = 0;
        public void Update(float dt) { if (!IsStopped) Remaining -= dt; }
        private float CalculateRemainingTime(float offset=0) => (float)(Util.Rand.NextDouble() * (Max - Min) + Min) + offset;
    }

    // +---------------------------------------------------------------------------------------------------------------
    // + Class: CountdownTimerDomain
    // + Description:
    // +    Insert Description Here
    // +---------------------------------------------------------------------------------------------------------------
    public class CountdownTimerDomain<T> where T : System.Enum
    {
        // Private Members  -------------------------------------------------------------------------------------------
        private float _elapsedTime = 0;
        private Dictionary<T, CountdownTimer> _timers = new Dictionary<T, CountdownTimer>();
        private List<T> _timerKeys = new List<T>();

        // Properties  ------------------------------------------------------------------------------------------------
        public float ElapsedTime { get => _elapsedTime; }
        public IReadOnlyDictionary<T, CountdownTimer> Timers { get => _timers; }
        public bool IsPaused { get; private set; } = false;

        // C'tor & Init Methods  --------------------------------------------------------------------------------------
        // public override void Initialize() {}
        // public override void Reinitialize() {}

        // Component Functionality  -----------------------------------------------------------------------------------
        public void AddTimer(T key, CountdownTimer timer)
        {
            if (!_timers.ContainsKey(key))
            {
                _timers[key] = timer;
                _timerKeys.Add(key);
            }
        }

        public void Reinitialize()
        {
            _elapsedTime = 0;
            for (var i = 0; i < _timerKeys.Count; ++i)
            {
                var key = _timerKeys[i];
                _timers[key].Restart();
            }
        }

        public void Pause() => IsPaused = true;
        public void Resume() => IsPaused = false;

        public void Update(float dt)
        {
            if (IsPaused) return;

            // var dt = Time.deltaTime;
            _elapsedTime += Time.deltaTime;
         
            for (var i = 0; i < _timerKeys.Count; ++i)
            {
                var key = _timerKeys[i];
                _timers[key].Update(dt);
            }
        }
    }
}
