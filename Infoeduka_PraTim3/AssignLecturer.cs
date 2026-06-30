using Infoeduka_PraTim3.Models;
using Infoeduka_PraTim3.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infoeduka_PraTim3
{
    public partial class AssignLecturer : Form
    {
        private int courseId;

        public AssignLecturer(int id, string course)
        {
            InitializeComponent();
            lblCourse.Text = course;
            courseId = id;
        }

        private void AssignLecturer_Load(object sender, EventArgs e)
        {
            CourseLecturerRepository courseLecturerRepository = new CourseLecturerRepository();

            LecturerRepository repository = new LecturerRepository();
            cblLecturers.DataSource = repository.GetAllLecturers();

            cblLecturers.DisplayMember = "FullName";
            cblLecturers.ValueMember = "Id";

            List<int> lecturerIds = courseLecturerRepository.GetLecturerIdsForCourse(courseId);

            for (int i = 0; i < cblLecturers.Items.Count; i++)
            {
                User user = (User)cblLecturers.Items[i];

                if (lecturerIds.Contains(user.Id))
                {
                    cblLecturers.SetItemChecked(i, true);
                }
            }

        }

        private void btnSaveLecturers_Click(object sender, EventArgs e)
        {
            int id = courseId; 

            CourseLecturerRepository repository = new CourseLecturerRepository();

            repository.DeleteByCourseId(id);

            foreach (User lecturer in cblLecturers.CheckedItems)
            {
                CourseLecturer courseLecturer = new CourseLecturer
                {
                    CourseId = id,
                    LecturerId = lecturer.Id
                };

                repository.AddCourseLecturer(courseLecturer);
            }

            MessageBox.Show("Predavači su uspješno spremljeni.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
