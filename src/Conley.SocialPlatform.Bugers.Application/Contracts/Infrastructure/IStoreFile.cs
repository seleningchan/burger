using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conley.SocialPlatform.Bugers.Application.Contracts.Infrastructure
{
    public interface IStoreFile
    {
		string Name
		{
			get;
		}
		string Extension
		{
			get;
		}
		long Size
		{
			get;
		}
		string RelativePath
		{
			get;
		}
		DateTime LastModified
		{
			get;
		}
	}
}
