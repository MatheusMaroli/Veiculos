using System.Collections.Generic;
using System.Linq;

namespace Utils.Web.Responses
{
    public class ResponseModelValidator : ResponseDefault
    {
        public IList<ErrorMessage> Errors {get;set;}
        
        public ResponseModelValidator() : base()
        {
            Errors = new List<ErrorMessage>();
        }

        public void SetError(string propertyName, string message)
        {
            Messages.Clear();
            SetWarning("Invalid property formatter");
            Errors.Add(new ErrorMessage(){PropertyName = propertyName, Message = message});
        }


    }
}