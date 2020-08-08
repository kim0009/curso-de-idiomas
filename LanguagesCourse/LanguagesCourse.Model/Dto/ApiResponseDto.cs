using System.Collections;

namespace LanguagesCourse.Model.Dto
{
    public class ApiResponseDto
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public ICollection Data { get; set; }
    }
}