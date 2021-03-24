using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentDataLayer
{
	public class Clients
	{
		[Key] public int IdClient { get; set; }
		[Required] public string LoginClient { get; set; }
		[Required] public string PasswordClient { get; set; }
		[Required] public string NameClient { get; set; }

		public Registry Registry { get; set; }
	}

	public class Doctors
	{
		[Key] public int IdDoctor { get; set; }
		[Required] public string NameDoctor { get; set; }

		public Specialties Specialty { get; set; }
	}

	public class Services
	{
		[Key] public int IdService { get; set; }
		[Required] public string NameService { get; set; }

		public Specialties Specialty { get; set; }
	}

	public class Specialties
	{
		[Key] public int IdSpecialty { get; set; }
		[Required] public int IdDoctor { get; set; }
		[Required] public int IdService { get; set; }

		public ICollection<Services> Service { get; set; }
		public ICollection<Doctors> Doctor { get; set; }
	}

	public class Registry
	{
		[Key]
		public int IdRegistry { get; set; }
		//public int IdDoctor { get; set; }
		//public int IdService { get; set; }
		public int IdSpecialty { get; set; }
		public DateTime AppointmentBegin { get; set; }
		public DateTime AppointmentEnd { get; set; }

		public ICollection<Clients> Client { get; set; }
		public ICollection<Specialties> Specialty { get; set; }
	}

	public class AppointmentsDbContext : DbContext
	{
		//public AppointmentsDbContext() : base("AppointmentsStomatology") {
		public AppointmentsDbContext() : base("DataSource=SASHAPC\\BEMCB;InitialCatalog=AppointmentsStomatology;Provider=SQLOLEDB;Persist Security Info=true")
		{
			//Database.SetInitializerInitialize<AppointmentsDbContext>(new AppointmentsInitializer());
			Database.SetInitializer<AppointmentsDbContext>(new DropCreateDatabaseIfModelChanges<AppointmentsDbContext>());
		}

		public DbSet<Clients> tbClient { get; set; }
		public DbSet<Doctors> tbDoctors { get; set; }
		public DbSet<Services> tbServices { get; set; }
		public DbSet<Specialties> tbSpecialties { get; set; }
		public DbSet<Registry> tbRegistry { get; set; }
	}

	public class AppointmentsInitializer : DropCreateDatabaseIfModelChanges<AppointmentsDbContext>
	{
		protected override void Seed(AppointmentsDbContext context) { base.Seed(context); }
	}

}
