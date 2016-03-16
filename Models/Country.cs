using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5
{
	
	// {"serial-number":6,"hash":"2778fa2a0a97b98728053b4caf7fee918aa0357c",
	// "entry":{"citizen-names":"Briton;British citizen",
	// "country":"GB",
	// "name":"United Kingdom","official-name":"The United Kingdom of Great Britain and Northern Ireland"}}
	public class Country
	{
		public int serialnumber { get; set; }
		public string hash { get; set; }
		public Entry entry { get; set; }
	}

	public class Entry
	{
		public string citizen_names { get; set; }
		public string country { get; set; }
		public string name { get; set; }
		public string official_name { get; set; }
	}


}
