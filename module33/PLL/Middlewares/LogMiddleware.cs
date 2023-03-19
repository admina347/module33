namespace module33
{
    public class LogMiddleware
    {
        private readonly ILoger _loger;
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next, ILoger loger)
        {
            _next = next;
            _loger = loger;
        }

        public static string GetIP(HttpContext httpContext)
        {
            return httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }


        public async Task Invoke(HttpContext httpContext)
        {
            //тут будет логика нашего Middleware
            _loger.WriteEvent("Я твой Middleware");
            //получить ip адрес и записать в лог событий
            _loger.WriteEvent("А я remote IP address: " + GetIP(httpContext));
            await _next(httpContext);
        }
    }
}