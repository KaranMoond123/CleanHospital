using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Result<T>:IResult<T>
    {
        public List<string> Messages { get; set; }
        public bool Successed { get; set; }
        public T Data { get; set; }
        public int code { get; set; }
        public string Token {  get; set; }
        public Exception Exception { get; set; }
        #region success
        public static Result<T> Success()
        {
            return new Result<T>
            {
                code = 200,
                Successed = true,
            };
        }
        public static Result<T> Success(string message)
        {
            return new Result<T>
            {
                code = 200,
                Successed = true,
                Messages = new List<string> { message }
            };
        }
        public static Result<T> Success(T  data,string message)
        {
            return new Result<T>
            {
                code = 200,
                Successed = true,
                Data = data,
                Messages = new List<string> { message }??null
            };
        }
        public static Result<T> Success(T data, string message,string? token)
        {
            return new Result<T>
            {
                code = 200,
                Successed = true,
                Data = data,
                Token=token,
                Messages = new List<string> { message } ?? null
            };
        }
        #endregion

        #region Bad Request

        public static Result<T> BadRequest( string message)
        {
            return new Result<T>
            {
                code = 400,
                Successed = false,
                Messages = new List<string> { message } ?? null
            };
        }
        #endregion

        #region
        public static Result<T> NotFound(T data, string message)
        {
            return new Result<T>
            {
                code = 204,
                Successed = false,
                Data = data,
                Messages = new List<string> { message } ?? null
            };
        }
        public static Result<T> NotFound( string message)
        {
            return new Result<T>
            {
                code = 204,
                Successed = false,
                Messages = new List<string> { message } ?? null
            };
        }
        #endregion

    }
}
