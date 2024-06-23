using System;

namespace MekaruStudios.MonsterCreator
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CustomizationEditorAttribute : Attribute
    {
        public CustomizationEditorAttribute()
        {
        }
    }
}
