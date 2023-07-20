using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentQuest.Data.Entities
{
	public class CandidateDocument:BaseEntity
	{
		public string Name { get; set; }
		public string Path { get; set; }
		public Guid ApplicationId { get; set; }
		public Application Application { get; set; }
	}
}
