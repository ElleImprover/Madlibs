using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

namespace Madlibs
{
    public class DatabaseData
    {
        public DatabaseData()
        {

        }

        public List<MadlibQA> CreateMadLibListFromSQL()
        {
            int rowCount = 0;
            List<MadlibQA> madlibs = new List<MadlibQA>();
            MadlibQA madlib = new MadlibQA();
            var connection = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();

                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select m.MadlibName as name, m.Madlib as madlib, q.question as question, m.MadlibId as madlibID, i.questionorder as orderid " +
                                  "from Questions as q join MadlibIndex as i on q.questionid=i.questionid" +
                                  " join Madlib as m on i.MadlibId =m.MadlibId order by m.MadlibId, questionorder";

                var reader = cmd.ExecuteReader();
                var curMadLib = "";
                while (reader.Read())//will have a row for each question; needs to create new madlib with name changes and assign all questions to that madlib
                {
                    var madLibName = reader["name"].ToString();

                    if (!madLibName.Equals(curMadLib))
                    {

                        if (!String.IsNullOrEmpty(madlib.Name))
                        {
                            madlibs.Add(madlib);
                        }
                        madlib = new MadlibQA();
                        madlib.Name = madLibName;
                        madlib.ID = Convert.ToInt32(reader["madlibID"]);
                        madlib.MadLib = reader["Madlib"].ToString();
                        QA qA = new QA();
                        qA.Question = reader["question"].ToString();
                        qA.OrderID = Convert.ToInt32(reader["orderid"]);
                        madlib.qaList.Add(qA);


                    }
                    else
                    {
                        QA qA = new QA();
                        qA.Question = reader["question"].ToString();
                        qA.OrderID = Convert.ToInt32(reader["orderid"]);
                        madlib.qaList.Add(qA);
                    }

                    curMadLib = madLibName;
                    rowCount++;

                }
            }

            if (rowCount > 0)
            {
                madlibs.Add(madlib);
            }

            return madlibs;
        }

        /* Unnecessary
       public List<MadlibOptions> GetMadlibsInDB()
       {
           List<MadlibOptions> optionList = new List<MadlibOptions>();

           var connection = ConfigurationManager.AppSettings["defaultConnection"];
           using (var conn = new SqlConnection(connection))

           {
               conn.Open();

               var cmd = new SqlCommand();
               cmd.Connection = conn;
               cmd.CommandType = System.Data.CommandType.Text;

               cmd.CommandText = "Select m.MadlibName, m.MadlibId from Madlib as m";
               var reader = cmd.ExecuteReader();


               while (reader.Read())
               {
                   MadlibOptions options = new MadlibOptions();
                   options.ID = Convert.ToInt32(reader["m.MadlibId"]);
                   options.Name = reader["m.MadlibName"].ToString();
                   optionList.Add(options);
               }
               return optionList;
           }

       }


       public MadlibQA CreateMadLibFromSQL(int madLibID)
       {
           var connection = ConfigurationManager.AppSettings["defaultConnection"];
           using (var conn = new SqlConnection(connection))

           {
               conn.Open();
               var cmd = new SqlCommand();
               cmd.Connection = conn;
               cmd.CommandType = System.Data.CommandType.Text;


               cmd.CommandText = "Select m.MadlibName,m.Madlib,q.question,i.questionorder " +
                                 "from Questions as q join MadlibIndex as i on q.questionid=i.questionid " +
                                 "join Madlib as m on i.MadlibId =m.MadlibId where m.MadlibId= @madLibID";
               cmd.Parameters.Add(new SqlParameter("@madLibID", madLibID));
               var reader = cmd.ExecuteReader();

               //List<QA> qaList = new List<QA>();
               MadlibQA madlib = new MadlibQA();

               //ED- This will set the same value multiple times; Should I do two different queries? one for questions and one for the madlibs?
               while (reader.Read())
               {
                   QA qA = new QA();
                   qA.Question = reader["question"].ToString();
                   madlib.qaList.Add(qA);
                   madlib.ID = Convert.ToInt32(reader["m.MadlibId"]);
                   madlib.Name = reader["m.MadlibName"].ToString();
                   madlib.MadLib = reader["m.Madlib"].ToString();
               }
               return madlib;
           }
       }
       */

    }
}
