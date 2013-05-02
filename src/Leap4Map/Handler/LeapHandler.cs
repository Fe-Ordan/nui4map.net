﻿using System;
using System.Linq;
using System.Windows;
using Leap;
using NUI4Map.Handler;

namespace Leap4Map.Handler
{
    public class LeapHandler : INUIHandler
    {
        public Controller controller;
        public LeapListener listener;

        #region Events
        public event Action<Controller> OnConnect;
        public event Action<Controller> OnDisconnect;
        public event Action<Controller> OnInitialize;
        public event Action<Controller> OnExit;
        public event Action<object> OnFrame;

        #endregion

        public void Start()
        {
            // Create a sample listener and controller
            listener = new LeapListener();
            controller = new Controller();

            // Have the sample listener receive events from the controller
            controller.AddListener(listener);

            OnConnect = listener.OnConnect;
            OnDisconnect = listener.OnDisconnect;
            OnInitialize = listener.OnInit;
            OnExit = listener.OnExit;
            listener.FrameEvent += listener_FrameEvent;
        }

        void listener_FrameEvent(Controller obj)
        {
            if (OnFrame != null)
            {
                OnFrame(obj);
            }
        }

        public void Stop()
        {
            // Remove the sample listener when done
            controller.RemoveListener(listener);
            controller.Dispose();
        }
    }

}