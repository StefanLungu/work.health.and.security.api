using System;
using System.Collections.Generic;

namespace whs.api.entities.management;

public class Department
{
	public Guid UniqueId { get; set; }
	public string Name { get; set; }
	public string IncrementalPath { get; set; }
	public bool IsActive { get; set; }
	public Department Parent { get; set; }
	public ICollection<Department> Departments { get; set; }
	public ICollection<User> Users { get; set; }
}
