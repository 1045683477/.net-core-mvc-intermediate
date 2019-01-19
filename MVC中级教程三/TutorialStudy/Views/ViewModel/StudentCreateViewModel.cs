using System;
using System.ComponentModel.DataAnnotations;
using TutorialStudy.Model;

namespace TutorialStudy.Views.ViewModel
{
    public class StudentCreateViewModel
    {
        //Required指定需要数据字段值
        [Display(Name = "姓"),Required,]
        public string LastName { get; set; }

        //MaxLength字符最大长度
        [Display(Name = "名"),Required,MaxLength(10)]
        public string FirstName { get; set; }

        [Display(Name = "性别")]
        public Gender Gender { get; set; }

        [Display(Name = "出生日期")]
        public DateTime BirthDate { get; set; }
    }
}
