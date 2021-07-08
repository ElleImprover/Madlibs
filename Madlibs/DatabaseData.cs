using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Madlibs
{
   public class DatabaseData
	{  
	private readonly IConfiguration _configuration;
	public DatabaseData(IConfiguration configuration)
	{
		_configuration = configuration;
	}
		public List<MadlibOptions> GetMadlibsInDB()
		{
			List<MadlibOptions> optionList = new List<MadlibOptions>();
			var connection = _configuration.GetConnectionString("default");
			using (var conn = new SqlConnection(connection))

			{
				conn.Open();

				var cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = System.Data.CommandType.Text;

				cmd.CommandText = "Select m.MadlibName, m.MadlibId" +
								  "from Madlib as m";
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
			var connection = _configuration.GetConnectionString("default");
			using (var conn = new SqlConnection(connection))

			{
				conn.Open(); 
				var cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandType = System.Data.CommandType.Text;

				//ED-Going to have to rewrite this; I can bypass all of this and only get the questions for the madlib
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

			public List<MadlibQA> CreateMadLibListFromSQL()
			{
			string curMadlibName = "";
			List<MadlibQA> madlibs = new List<MadlibQA>();
				var connection = _configuration.GetConnectionString("default");
				using (var conn = new SqlConnection(connection)) 
				{
					conn.Open();

					var cmd = new SqlCommand();
					cmd.Connection = conn;
					cmd.CommandType = System.Data.CommandType.Text; 
					cmd.CommandText = "Select m.MadlibName,m.Madlib,q.question,m.MadlibId,i.questionorder " +
									  "from Questions as q join MadlibIndex as i on q.questionid=i.questionid " +
									  "join Madlib as m on i.MadlibId =m.MadlibId where m.MadlibId= @madLibID order by m.MadlibId";
					
					var reader = cmd.ExecuteReader();

					//MadlibQA madlib = new MadlibQA();
					//ED- Need to convert this into a madLibQAList
					while (reader.Read())//will have a row for each question; needs to create new madlib with name changes and assign all questions to that madlib
					{
						MadlibQA madlib = new MadlibQA();
					while () {
						QA qA = new QA();
						qA.Question = reader["question"].ToString();
						madlib.qaList.Add(qA);
						madlib.ID = Convert.ToInt32(reader["m.MadlibId"]);
						madlib.Name = reader["m.MadlibName"].ToString();
						madlib.MadLib = reader["m.Madlib"].ToString();
					}
							
					//	}

					}
					return madlibs;
				}


			}

		
	}
}
