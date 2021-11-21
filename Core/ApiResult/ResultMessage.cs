using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ApiResult
{
    public class ResultMessage
    {
        public static string Success => "messages.success.general.ok";
        public static string InvalidModel => "messages.error.general.invalidModel";
        public static string UnhandledException => "messages.error.general.unhandledException";
        public static string UnAuthorized => "messages.error.general.unAuthorized";
        public static string Forbidden => "messages.error.general.Forbidden";

        public static string InternalServerError => "messages.error.general.internalServerError";
    }
}