using ControleBovideoSquad.CrossCutting.Enums;

namespace ControleBovideoSquad.CrossCutting.Util
{
    public class Result<TResult>
    {
        public EStatusCode StatusCode { get; }
        public TResult? Data { get; }
        public ICollection<string>? Errors { get; }

        protected Result(EStatusCode statusCode, TResult data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        protected Result(EStatusCode statusCode, params string[] msgError)
        {
            StatusCode = statusCode;
            Errors = new List<string>();

            foreach (var msg in msgError)
            {
                Errors.Add(msg);
            }
        }

        protected Result(EStatusCode statusCode, IEnumerable<string> errors)
        {
            StatusCode = statusCode;
            Errors = new List<string>();
            foreach (var error in errors)
            {
                Errors.Add(error);
            }
        }

        public static Result<TResult> Error(EStatusCode statusCode, string msgError) { return new Result<TResult>(statusCode, msgError); }
        public static Result<TResult> Error(EStatusCode statusCode, IEnumerable<string> msgError) { return new Result<TResult>(statusCode, msgError); }
        public static Result<TResult> Success(TResult data) { return new Result<TResult>(EStatusCode.OK, data); }

    }
}
