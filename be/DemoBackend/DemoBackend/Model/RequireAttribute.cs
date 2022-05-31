using System;

namespace DemoBackend.Model
{
    internal class RequireAttribute : Attribute
    {
        public string ErrorMessage;
    }
}