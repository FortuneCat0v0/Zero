using System;
using System.Collections.Generic;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class MainWindow : IMainWindow, IWindowWidthSubject 
    {
        readonly List<IWindow> _windows = new List<IWindow>();
        readonly List<IWindow> _queuedWindows = new List<IWindow>();
        readonly IPreviewEntityModel _previewEntity;
        
        // Handle window with
        readonly List<IWindowWidthObserver> _withObservers = new List<IWindowWidthObserver>();

        bool _isWindowsChanged;
        


        public MainWindow()
        {
            _previewEntity = ServiceLocator.Instance.Resolve<IPreviewEntityModel>();
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _previewEntity.Create(cube);
            UnityEngine.Object.DestroyImmediate(cube);
        }

        public void Destroy()
        {
            _previewEntity.Destroy();

            foreach (var window in _windows)
                window.OnExit();
        }

        public void Append(IWindow window)
        {
            _windows.Add(window);
            _queuedWindows.Add(window);
            _isWindowsChanged = true;
            
            window.OnEnter();
        }
        public void Render(float pWidth)
        {
            NotifyObservers(pWidth);
            const float spaceBetweenAreas = 2; // Adjust this value to control the space between areas.
            var xPos = 0f;

            if (_isWindowsChanged)
            {
                _isWindowsChanged = false;
                _windows.Clear();
                _windows.AddRange(_queuedWindows);
            }
            
            foreach (var window in _windows)
            {
                var width = (pWidth - (_windows.Count - 1) * spaceBetweenAreas) * window.WidthPercentage;
                var rect = new Rect(xPos, 0, width, Screen.height);
                GUILayout.BeginArea(rect, GUI.skin.box);
                window.Render();
                GUILayout.EndArea();
                xPos += width + spaceBetweenAreas;
            }

        }
        public void ReplaceWindow(IWindow window, int index)
        {
            if (index > _windows.Count - 1 || index < 0)
                throw new ArgumentException("Error while trying to replace window, window index is invalid!");

            var windowToReplace = GetWindow(index);
            windowToReplace.OnExit();
            
            _queuedWindows.Clear();
            _queuedWindows.AddRange(_windows);
            _queuedWindows[index] = window;
            _isWindowsChanged = true;
            
            window.OnEnter();
        }
        public IWindow GetWindow(int index) => _isWindowsChanged ? _queuedWindows[index] : _windows[index];


        public void RegisterObserver(IWindowWidthObserver observer)
        {
            _withObservers.Add(observer);
        }
        public void UnregisterObserver(IWindowWidthObserver observer)
        {
            _withObservers.Remove(observer);
        }
        public void NotifyObservers(float width)
        {
            foreach (var observer in _withObservers)
                observer.UpdateWidth(width);
        }
    }
}
