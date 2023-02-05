using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace _Game_.Scripts.Managers
{
    public class ControllerHub : Singleton<ControllerHub>
    {
        [SerializeField] private List<BaseController> _controllersPriorityList;

        private readonly Dictionary<Type, BaseController> _controllers = new Dictionary<Type, BaseController>();

        private void Start()
        {
            PopulateDictionary();
            InitControllers();
        }

        private void PopulateDictionary()
        {
            foreach (BaseController baseController in _controllersPriorityList)
            {
                _controllers.Add(baseController.GetType(), baseController);
            }
        }

        private void InitControllers()
        {
            foreach (BaseController baseController in _controllersPriorityList)
            {
                baseController.Init();
            }
        }
        
        public static T Get<T>() where T : BaseController
        {
            return (T)Instance._controllers[typeof(T)];
        }
    }
}