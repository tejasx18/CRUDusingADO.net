namespace CRUDusingADO.Models
{
    using Microsoft.Data.SqlClient;
    public class StudentCRUD
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        IConfiguration configuration;

        public StudentCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection( this.configuration.GetConnectionString("DefaultConnection"));
        }

        public List<Student> GetStudents()
        {
            List<Student> Students = new List<Student>();
            cmd = new SqlCommand("select * from student", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student Student = new Student();
                    Student.RollNo = Convert.ToInt32(dr["rollno"]);
                    Student.Name = dr["name"].ToString();
                    Student.Branch = dr["branch"].ToString();
                    Student.Percentage = Convert.ToDouble(dr["percentage"]);
                    Students.Add(Student);
                }
            }
            con.Close();
            return Students;
        }
        public Student GetStudentById(int id)
        {
            Student Student = new Student();
            cmd = new SqlCommand("select * from student where rollno=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student.RollNo = Convert.ToInt32(dr["rollno"]);
                    Student.Name = dr["name"].ToString();
                    Student.Branch = dr["branch"].ToString();
                    Student.Percentage = Convert.ToDouble(dr["percentage"]);

                }
            }
            con.Close();
            return Student;
        }
        public int AddStudent(Student std)
        {
            int result = 0;
            string qry = "insert into student values(@name,@percentage,@branch)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", std.Name);
            cmd.Parameters.AddWithValue("@branch", std.Branch);
            cmd.Parameters.AddWithValue("@percentage", std.Percentage);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student std)
        {
            int result = 0;
            string qry = "update student set name=@name,branch=@branch,percentage=@percentage where rollno=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", std.Name);
            cmd.Parameters.AddWithValue("@branch", std.Branch);
            cmd.Parameters.AddWithValue("@percentage", std.Percentage);
            cmd.Parameters.AddWithValue("@id", std.RollNo);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "delete from Student where rollno=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
