using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomeResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }

        public static CustomeResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomeResponseDto<T>{StatusCode = statusCode, Data = data,Errors = null};
        }

        public static CustomeResponseDto<T> Success(int statusCode)
        {
            return new CustomeResponseDto<T> { StatusCode = statusCode, Errors = null };
        }

        public static CustomeResponseDto<T> Fail(List<string> errors, int statusCode)
        {
            return new CustomeResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }
        public static CustomeResponseDto<T> Fail(string error, int statusCode)
        {
            return new CustomeResponseDto<T> { StatusCode = statusCode, Errors = new List<string>{error} };
        }



    }
}
