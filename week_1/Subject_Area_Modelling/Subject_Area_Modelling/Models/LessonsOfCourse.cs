using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subject_Area_Modelling.Models
{
    internal class LessonsOfCourse
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
