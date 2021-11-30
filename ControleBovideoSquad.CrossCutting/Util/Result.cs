using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBovideoSquad.CrossCutting.Util
{
    public class Result<TResult>
    {
        public int StatusCode { get;}
        public TResult Data { get; }
        public ICollection<string> Errors { get;}
        
        protected Result(int statusCode, TResult data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        protected Result(int statusCode, params string[] msgError)
        {
            StatusCode = statusCode;
            Errors = new List<string>();

            foreach(var msg in msgError)
            {
                Errors.Add(msg);
            }     
        }

        protected Result(int statusCode, IEnumerable<string> errors)
        {
            StatusCode = statusCode;
            Errors = new List<string>();
            foreach(var error in errors)
            {
                Errors.Add(error);
            }
        }

        public static Result<TResult> Error(string msgError) { return new Result<TResult>(400,msgError); }
        public static Result<TResult> Error(IEnumerable<string> msgError) { return new Result<TResult>(400, msgError); }
        public static Result<TResult> Success(TResult data) { return new Result<TResult>(200, data); }
        
    }
}
