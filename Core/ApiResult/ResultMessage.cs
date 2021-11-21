using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ApiResult
{
    public class ResultMessage
    {
        public static string Success => "messages.success.general.ok";
        public static string Error => "messages.error.general.false";
        public static string InvalidModel => "messages.error.general.invalidModel";
        public static string UnhandledException => "messages.error.general.unhandledException";
        public static string UnAuthorized => "messages.error.general.unAuthorized";
        public static string Forbidden => "messages.error.general.Forbidden";

        public static string InternalServerError => "messages.error.general.internalServerError";

        public static string NotFoundCategory => "messages.error.category.notFoundCategory";

        public static string NotFoundComment => "messages.error.category.notFoundComment";
        
        public static string NotFoundFood => "messages.error.category.notFoundFood";
    }
}