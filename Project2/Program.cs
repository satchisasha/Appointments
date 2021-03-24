using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentDataLayer
{
	internal class Program
	{
		private static void Main()
		{
			using (var ctx = new AppointmentsDbContext())
			{
				//var doctors = new tbDoctor() { NameDoctor = "Andrew", };
				//cns.TbDoctors.Add(doctors);

				var services = new Services() { NameService = "Dignostic", };
				ctx.tbServices.Add(services);
				ctx.SaveChanges();
			}
		}
	}
}
