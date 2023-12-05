namespace Domain.DTOs
{
    public class ExamCreationDto
    {
        public string NameOfExam { get; set; }
        public int IdOfExam { get; set; }
        public string DateTime { get; set; }
        public Class Class { get; set; }

       
        public ExamCreationDto() { }

        public ExamCreationDto(string nameOfExam, string dateTime, Class class_)
        {
            NameOfExam = nameOfExam;
            DateTime = dateTime;
            Class = class_;
        }
    }
}