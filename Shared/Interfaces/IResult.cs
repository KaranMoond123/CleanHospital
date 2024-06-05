using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IResult<T>
    {
        List<string> Messages { get; set; }
        bool Successed { get; set; }
        T Data { get; set; }
        int code {  get; set; }
        string Token {  get; set; }
        Exception Exception { get; set; }
    }
}
