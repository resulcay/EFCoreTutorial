using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTutorial.Common
{
	public class StringConstants
	{
		public static string DbConnectionString { get; } = "Data Source=(localdb)\\CoreDemo;Initial Catalog=EFCoreTutorial;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
	}
}
