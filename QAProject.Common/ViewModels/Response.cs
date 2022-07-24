using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Common.ViewModels;

public class Response<T>
{
	public T? Data { get; set; }

	public long RecordsTotal { get; set; }

	public long RecordsFiltered { get; set; }

	public bool IsSuccess { get; set; }

	public short Result { get; set; }

	public string? Message { get; set; }

	public dynamic? ChangedId { get; set; }

}

public class Response
{
	public dynamic? Data { get; set; }

	public long RecordsTotal { get; set; }

	public long RecordsFiltered { get; set; }

	public bool IsSuccess { get; set; }

	public short Result { get; set; }

	public string? Message { get; set; }

	public dynamic? ChangedId { get; set; }
}
