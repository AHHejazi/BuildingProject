using System;

namespace ComponentsLibrary.ErrorHandler
{
    public interface IErrorComponent
    {
        void SetError(string title, string message);
        void ProcessError(Exception ex);
    }
}