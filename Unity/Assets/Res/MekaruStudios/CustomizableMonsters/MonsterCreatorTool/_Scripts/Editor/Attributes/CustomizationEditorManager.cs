using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MekaruStudios.MonsterCreator
{
    public static class CustomizationEditorManager
    {
        static List<Type> _customizationEditorTypes;
        public static IReadOnlyList<Type> CustomizationEditorTypes
        {
            get
            {
                if (_customizationEditorTypes == null)
                {
                    FindCustomizationEditorTypes();
                }

                return _customizationEditorTypes;
            }
        }

        static void FindCustomizationEditorTypes()
        {
            _customizationEditorTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.GetCustomAttributes(typeof(CustomizationEditorAttribute), true).Length > 0)
                .ToList();
        }
        
    }

}
