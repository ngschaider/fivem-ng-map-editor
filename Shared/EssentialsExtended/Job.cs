using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialsExtended {
    public class Job {

        public dynamic Raw;
        public int Id => Raw.id;
        public string Name => Raw.name;
        public string Label => Raw.label;
        public int Grade => Raw.grade;
        public string GradeName => Raw.grade_name;
        public string GradeLabel => Raw.grade_label;
        public int GradeSalary => Raw.grade_salary;
        public dynamic SkinMale => Raw.skin_male;
        public dynamic SkinFemale => Raw.skin_female;

        public Job() {
        }

        public Job(dynamic data) => Raw = data;

    }
}
