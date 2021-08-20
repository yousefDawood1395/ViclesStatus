﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ViclesStatus.Timer_Manager
{
    public class TimerManager
    {
        private Timer _timer;
        private AutoResetEvent _autoResetEvent;
        private Action _action;
        public DateTime TimerStarted { get; }
        public TimerManager(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 2000, 10000);
            TimerStarted = DateTime.Now;
        }
        public void Execute(object stateInfo)
        {
            _action();
            if ((DateTime.Now - TimerStarted).Seconds > 240)
            {
                _timer.Dispose();
            }
        }
    }
}
