using DB.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Server
{
	public class DBHub : Hub
	{
		public void PrihvatiOsobu(Osoba o)
		{
			EF baza = new EF();
			baza.Osobas.Add(o);
			baza.SaveChanges();
			PosaljiOsobe();
		}

		public void PosaljiOsobe()
		{
			EF baza = new EF();
			Clients.All.SendAsync("DodajOsobe", baza.Osobas.ToList());
		}

		public void ObrisiOsobu(Osoba o)
		{
			EF baza = new EF();
			baza.Osobas.Remove(o);
			baza.SaveChanges();
			PosaljiOsobe();
		}
	}
}
